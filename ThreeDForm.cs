using System;
using System.Drawing;
using System.Windows.Forms;

using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

using System.Drawing.Imaging;
using DrawingPixelFormat = System.Drawing.Imaging.PixelFormat;
using GLPixelFormat = OpenTK.Graphics.OpenGL.PixelFormat;

namespace PixelLab
{
    public partial class ThreeDForm : Form
    {
        // انواع الانظمة اللونية
        private enum ColorSpaceMode
        {
            RGB,
            CMYK,
            HSV,
            YCbCr,
            YUV,
            LAB
        }
        //ثوابت
        private const float CubeSize = 255f;
        private const float SceneCenter = CubeSize / 2f;
        private const float AxisLength = 320f;
        private const int CircleSegments = 120;

        private GLControl _glControl;
        private ColorSpaceMode _currentMode = ColorSpaceMode.RGB;

        private float _kValue = 0.0f;
        private float _ycbcrYValue = 128f;
        private float _labLightness = 50f;
        private float _labChroma = 80f;

        private float _rotationX = 25f;
        private float _rotationY = -35f;
        private float _zoom = -650f;

        private bool _isDragging = false;
        private Point _lastMousePosition;

        private Point _dragStartPosition;
        private bool _mouseMovedWhileDragging = false;
        private const int ClickTolerance = 4;

        public ThreeDForm()
        {
            InitializeComponent();
            InitializeOpenGlViewer();
            InitializeColorSpaceControls();
        }

        private void InitializeOpenGlViewer()
        {
            _glControl = new GLControl(new GraphicsMode(32, 24, 0, 4));
            _glControl.Dock = DockStyle.Fill;
            _glControl.BackColor = Color.Black;

            panel3D.Controls.Add(_glControl);

            _glControl.Load += GlControl_Load;
            _glControl.Paint += GlControl_Paint;
            _glControl.Resize += GlControl_Resize;

            _glControl.MouseDown += GlControl_MouseDown;
            _glControl.MouseMove += GlControl_MouseMove;
            _glControl.MouseUp += GlControl_MouseUp;
            _glControl.MouseWheel += GlControl_MouseWheel;
        }

        private void InitializeColorSpaceControls()
        {
            change_color_space.Items.Clear();
            change_color_space.Items.Add("RGB");
            change_color_space.Items.Add("CMYK");
            change_color_space.Items.Add("HSV");
            change_color_space.Items.Add("YCbCr");
            change_color_space.Items.Add("YUV");
            change_color_space.Items.Add("LAB");

            change_color_space.DropDownStyle = ComboBoxStyle.DropDownList;
            change_color_space.SelectedIndex = 0;

            change_color_space.SelectedIndexChanged += ChangeColorSpace_SelectedIndexChanged;
            trackBarBlack.Scroll += TrackBarBlack_Scroll;
            trackBarLuma.Scroll += TrackBarLuma_Scroll;
            trackBarLabLightness.Scroll += TrackBarLabLightness_Scroll;
            trackBarLabChroma.Scroll += TrackBarLabChroma_Scroll;

            UpdateControlsVisibility();
        }

        private void ChangeColorSpace_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedMode = change_color_space.SelectedItem == null
                ? "RGB"
                : change_color_space.SelectedItem.ToString();

            _currentMode = (ColorSpaceMode)Enum.Parse(typeof(ColorSpaceMode), selectedMode);

            UpdateControlsVisibility();
            Redraw();
        }

        private void TrackBarBlack_Scroll(object sender, EventArgs e)
        {
            _kValue = trackBarBlack.Value / 100.0f;
            BlackValue.Text = "K = " + trackBarBlack.Value + "%";
            Redraw();
        }

        private void TrackBarLuma_Scroll(object sender, EventArgs e)
        {
            _ycbcrYValue = trackBarLuma.Value;
            LumaValue.Text = "Y = " + trackBarLuma.Value;
            Redraw();
        }

        private void TrackBarLabLightness_Scroll(object sender, EventArgs e)
        {
            _labLightness = trackBarLabLightness.Value;
            LabLightnessValue.Text = "L* = " + trackBarLabLightness.Value;
            Redraw();
        }

        private void TrackBarLabChroma_Scroll(object sender, EventArgs e)
        {
            _labChroma = trackBarLabChroma.Value;
            LabChromaValue.Text = "C* = " + trackBarLabChroma.Value;
            Redraw();
        }

        private void UpdateControlsVisibility()
        {
            bool isCmyk = _currentMode == ColorSpaceMode.CMYK;
            bool usesLumaSlider = _currentMode == ColorSpaceMode.YCbCr ||
                                  _currentMode == ColorSpaceMode.YUV;
            bool isLab = _currentMode == ColorSpaceMode.LAB;

            SetControlPairVisibility(trackBarBlack, BlackValue, isCmyk);
            SetControlPairVisibility(trackBarLuma, LumaValue, usesLumaSlider);
            SetControlPairVisibility(trackBarLabLightness, LabLightnessValue, isLab);
            SetControlPairVisibility(trackBarLabChroma, LabChromaValue, isLab);
        }

        private void SetControlPairVisibility(Control control, Control label, bool visible)
        {
            control.Visible = visible;
            label.Visible = visible;

            if (visible)
            {
                control.BringToFront();
                label.BringToFront();
            }
        }

        private void GlControl_Load(object sender, EventArgs e)
        {
            GL.ClearColor(0f, 0f, 0f, 1f);
            GL.Enable(EnableCap.DepthTest);
            GL.ShadeModel(ShadingModel.Smooth);

            SetupViewport();
        }

        private void GlControl_Resize(object sender, EventArgs e)
        {
            SetupViewport();
            Redraw();
        }

        private void SetupViewport()
        {
            if (_glControl == null || _glControl.ClientSize.Height == 0)
                return;

            GL.Viewport(0, 0, _glControl.ClientSize.Width, _glControl.ClientSize.Height);

            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();

            double aspect = _glControl.ClientSize.Width / (double)_glControl.ClientSize.Height;

            Matrix4 perspective = Matrix4.CreatePerspectiveFieldOfView(
                MathHelper.DegreesToRadians(45f),
                (float)aspect,
                1f,
                2000f
            );

            GL.LoadMatrix(ref perspective);
            GL.MatrixMode(MatrixMode.Modelview);
        }

        private void GlControl_Paint(object sender, PaintEventArgs e)
        {
            RenderScene();
            _glControl.SwapBuffers();
        }

        private void RenderScene()
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();

            GL.Translate(0f, 0f, _zoom);
            GL.Rotate(_rotationX, 1f, 0f, 0f);
            GL.Rotate(_rotationY, 0f, 1f, 0f);
            GL.Translate(-SceneCenter, -SceneCenter, -SceneCenter);

            DrawCurrentColorSpace();
        }

        private void DrawCurrentColorSpace()
        {
            switch (_currentMode)
            {
                case ColorSpaceMode.RGB:
                    DrawColorCube(SetVertexWithRgbColor);
                    DrawCubeEdges();
                    DrawAxes(Color.Red, Color.Lime, Color.Blue);
                    DrawAxisLabels(
                        "R", Color.Red,
                        "G", Color.Lime,
                        "B", Color.Blue
                    );
                    break;

                case ColorSpaceMode.CMYK:
                    DrawColorCube(SetVertexWithCmykColor);
                    DrawCubeEdges();
                    DrawAxes(Color.Cyan, Color.Magenta, Color.Yellow);
                    DrawAxisLabels(
                        "C", Color.Cyan,
                        "M", Color.Magenta,
                        "Y", Color.Yellow
                    );
                    break;

                case ColorSpaceMode.HSV:
                    DrawHsvCone();
                    DrawHsvAxes();
                    DrawHsvAxisLabels();
                    break;

                case ColorSpaceMode.YCbCr:
                    DrawLumaChromaSlice(YcbcrToRgb);
                    DrawHorizontalSquareFrame(_ycbcrYValue);
                    DrawAxes(Color.DeepSkyBlue, Color.White, Color.OrangeRed);
                    DrawAxisLabels(
                        "Cb", Color.DeepSkyBlue,
                        "Y", Color.White,
                        "Cr", Color.OrangeRed
                    );
                    break;

                case ColorSpaceMode.YUV:
                    DrawLumaChromaSlice(YuvToRgb);
                    DrawHorizontalSquareFrame(_ycbcrYValue);
                    DrawAxes(Color.DeepSkyBlue, Color.White, Color.OrangeRed);
                    DrawAxisLabels(
                        "U", Color.DeepSkyBlue,
                        "Y", Color.White,
                        "V", Color.OrangeRed
                    );
                    break;

                case ColorSpaceMode.LAB:
                    DrawLabDisk();
                    DrawCircleFrame(SceneCenter, _labLightness * 2.55f, SceneCenter, _labChroma);
                    DrawLabAxes();
                    DrawLabAxisLabels();
                    break;
            }
        }

        // DRAWING HELPERS
        private void Redraw()
        {
            if (_glControl != null)
                _glControl.Invalidate();
        }

        private void SetOpenGlColor(Color color)
        {
            GL.Color3(color.R / 255f, color.G / 255f, color.B / 255f);
        }

        private void EmitColoredVertex(Color color, float x, float y, float z)
        {
            SetOpenGlColor(color);
            GL.Vertex3(x, y, z);
        }

        private void DrawLine(float x1, float y1, float z1, float x2, float y2, float z2)
        {
            GL.Vertex3(x1, y1, z1);
            GL.Vertex3(x2, y2, z2);
        }

        private void DrawColoredLine(Color color, float x1, float y1, float z1, float x2, float y2, float z2)
        {
            SetOpenGlColor(color);
            DrawLine(x1, y1, z1, x2, y2, z2);
        }

        private void DrawAxes(Color xAxisColor, Color yAxisColor, Color zAxisColor)
        {
            GL.LineWidth(4f);
            GL.Begin(PrimitiveType.Lines);

            DrawColoredLine(xAxisColor, 0f, 0f, 0f, AxisLength, 0f, 0f);
            DrawColoredLine(yAxisColor, 0f, 0f, 0f, 0f, AxisLength, 0f);
            DrawColoredLine(zAxisColor, 0f, 0f, 0f, 0f, 0f, AxisLength);

            GL.End();
        }

        private void DrawText3D(string text, float x, float y, float z, Color color)
        {
            using (Font font = new Font("Arial", 16, FontStyle.Bold))
            {
                Size textSize = TextRenderer.MeasureText(text, font);

                using (Bitmap bitmap = new Bitmap(textSize.Width + 8, textSize.Height + 8, DrawingPixelFormat.Format32bppArgb))
                {
                    using (Graphics graphics = Graphics.FromImage(bitmap))
                    {
                        graphics.Clear(Color.Transparent);

                        using (Brush brush = new SolidBrush(color))
                        {
                            graphics.DrawString(text, font, brush, 0, 0);
                        }
                    }

                    bitmap.RotateFlip(RotateFlipType.RotateNoneFlipY);

                    BitmapData data = bitmap.LockBits(
                        new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                        ImageLockMode.ReadOnly,
                        DrawingPixelFormat.Format32bppArgb
                    );

                    GL.Disable(EnableCap.DepthTest);

                    GL.Enable(EnableCap.Blend);
                    GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);

                    GL.RasterPos3(x, y, z);

                    GL.DrawPixels(
                        data.Width,
                        data.Height,
                        GLPixelFormat.Bgra,
                        PixelType.UnsignedByte,
                        data.Scan0
                    );

                    bitmap.UnlockBits(data);

                    GL.Disable(EnableCap.Blend);
                    GL.Enable(EnableCap.DepthTest);
                }
            }
        }

        private void DrawAxisLabels(
            string xLabel, Color xColor,
            string yLabel, Color yColor,
            string zLabel, Color zColor)
        {
            DrawText3D(xLabel, AxisLength + 10f, 0f, 0f, xColor);
            DrawText3D(yLabel, 0f, AxisLength + 10f, 0f, yColor);
            DrawText3D(zLabel, 0f, 0f, AxisLength + 10f, zColor);
        }

        private void DrawHsvAxisLabels()
        {
            DrawText3D("V", SceneCenter + 8f, AxisLength + 10f, SceneCenter, Color.White);
            DrawText3D("S", AxisLength + 10f, CubeSize, SceneCenter, Color.Yellow);
            DrawText3D("H", SceneCenter, CubeSize, AxisLength + 10f, Color.Red);
        }

        private void DrawLabAxisLabels()
        {
            DrawText3D("L*", SceneCenter + 8f, AxisLength + 10f, SceneCenter, Color.White);

            DrawText3D("+a*", SceneCenter + 170f, SceneCenter, SceneCenter, Color.Red);
            DrawText3D("-a*", SceneCenter - 205f, SceneCenter, SceneCenter, Color.Lime);

            DrawText3D("+b*", SceneCenter, SceneCenter, SceneCenter + 170f, Color.Yellow);
            DrawText3D("-b*", SceneCenter, SceneCenter, SceneCenter - 205f, Color.Blue);
        }

        private void DrawCircleFrame(float centerX, float y, float centerZ, float radius)
        {
            GL.LineWidth(2f);
            GL.Color3(1f, 1f, 1f);
            GL.Begin(PrimitiveType.LineLoop);

            for (int i = 0; i < CircleSegments; i++)
            {
                double angle = i / (double)CircleSegments * Math.PI * 2.0;
                float x = centerX + radius * (float)Math.Cos(angle);
                float z = centerZ + radius * (float)Math.Sin(angle);
                GL.Vertex3(x, y, z);
            }

            GL.End();
        }

        private void DrawHorizontalSquareFrame(float y)
        {
            GL.LineWidth(2f);
            GL.Color3(1f, 1f, 1f);
            GL.Begin(PrimitiveType.Lines);

            DrawLine(0, y, 0, CubeSize, y, 0);
            DrawLine(CubeSize, y, 0, CubeSize, y, CubeSize);
            DrawLine(CubeSize, y, CubeSize, 0, y, CubeSize);
            DrawLine(0, y, CubeSize, 0, y, 0);

            GL.End();
        }

        // RGB / CMYK CUBE
        private void DrawColorCube(Action<float, float, float> setVertexColorAndPosition)
        {
            GL.Begin(PrimitiveType.Quads);

            DrawColorFace(setVertexColorAndPosition, 0, 0, 0, 0, CubeSize, 0, 0, 0, CubeSize);              // X = 0
            DrawColorFace(setVertexColorAndPosition, CubeSize, 0, 0, CubeSize, CubeSize, 0, CubeSize, 0, CubeSize); // X = 255
            DrawColorFace(setVertexColorAndPosition, 0, 0, 0, CubeSize, 0, 0, 0, 0, CubeSize);              // Y = 0
            DrawColorFace(setVertexColorAndPosition, 0, CubeSize, 0, CubeSize, CubeSize, 0, 0, CubeSize, CubeSize); // Y = 255
            DrawColorFace(setVertexColorAndPosition, 0, 0, 0, CubeSize, 0, 0, 0, CubeSize, 0);              // Z = 0
            DrawColorFace(setVertexColorAndPosition, 0, 0, CubeSize, CubeSize, 0, CubeSize, 0, CubeSize, CubeSize); // Z = 255

            GL.End();
        }

        private void DrawColorFace(
            Action<float, float, float> setVertexColorAndPosition,
            float x1, float y1, float z1,
            float x2, float y2, float z2,
            float x3, float y3, float z3)
        {
            float x4 = x2 + x3 - x1;
            float y4 = y2 + y3 - y1;
            float z4 = z2 + z3 - z1;

            setVertexColorAndPosition(x1, y1, z1);
            setVertexColorAndPosition(x2, y2, z2);
            setVertexColorAndPosition(x4, y4, z4);
            setVertexColorAndPosition(x3, y3, z3);
        }

        private void SetVertexWithRgbColor(float r, float g, float b)
        {
            GL.Color3(r / CubeSize, g / CubeSize, b / CubeSize);
            GL.Vertex3(r, g, b);
        }

        private void SetVertexWithCmykColor(float c255, float m255, float y255)
        {
            float c = c255 / CubeSize;
            float m = m255 / CubeSize;
            float y = y255 / CubeSize;

            float r = (1f - c) * (1f - _kValue);
            float g = (1f - m) * (1f - _kValue);
            float b = (1f - y) * (1f - _kValue);

            GL.Color3(r, g, b);
            GL.Vertex3(c255, m255, y255);
        }

        private void DrawCubeEdges()
        {
            float[,] edges =
            {
                {0, 0, 0, CubeSize, 0, 0},
                {0, 0, 0, 0, CubeSize, 0},
                {0, 0, 0, 0, 0, CubeSize},

                {CubeSize, 0, 0, CubeSize, CubeSize, 0},
                {CubeSize, 0, 0, CubeSize, 0, CubeSize},

                {0, CubeSize, 0, CubeSize, CubeSize, 0},
                {0, CubeSize, 0, 0, CubeSize, CubeSize},

                {0, 0, CubeSize, CubeSize, 0, CubeSize},
                {0, 0, CubeSize, 0, CubeSize, CubeSize},

                {CubeSize, CubeSize, CubeSize, CubeSize, CubeSize, 0},
                {CubeSize, CubeSize, CubeSize, CubeSize, 0, CubeSize},
                {CubeSize, CubeSize, CubeSize, 0, CubeSize, CubeSize}
            };

            GL.LineWidth(2f);
            GL.Color3(1f, 1f, 1f);
            GL.Begin(PrimitiveType.Lines);

            for (int i = 0; i < edges.GetLength(0); i++)
            {
                DrawLine(edges[i, 0], edges[i, 1], edges[i, 2], edges[i, 3], edges[i, 4], edges[i, 5]);
            }

            GL.End();
        }

        // HSV CONE
        private void DrawHsvCone()
        {
            DrawHsvConeSide(CircleSegments);
            DrawPolarDisk(
                SceneCenter,
                CubeSize,
                SceneCenter,
                SceneCenter,
                30,
                CircleSegments,
                delegate (float hue, float radius, float normalizedRadius)
                {
                    return HsvToRgb(hue, normalizedRadius, 1f);
                }
            );
        }

        private void DrawHsvConeSide(int hueSegments)
        {
            GL.Begin(PrimitiveType.Triangles);

            for (int i = 0; i < hueSegments; i++)
            {
                float h1 = i / (float)hueSegments;
                float h2 = (i + 1) / (float)hueSegments;

                double angle1 = h1 * Math.PI * 2.0;
                double angle2 = h2 * Math.PI * 2.0;

                float x1 = SceneCenter + SceneCenter * (float)Math.Cos(angle1);
                float z1 = SceneCenter + SceneCenter * (float)Math.Sin(angle1);
                float x2 = SceneCenter + SceneCenter * (float)Math.Cos(angle2);
                float z2 = SceneCenter + SceneCenter * (float)Math.Sin(angle2);

                GL.Color3(0f, 0f, 0f);
                GL.Vertex3(SceneCenter, 0f, SceneCenter);

                EmitColoredVertex(HsvToRgb(h1, 1f, 1f), x1, CubeSize, z1);
                EmitColoredVertex(HsvToRgb(h2, 1f, 1f), x2, CubeSize, z2);
            }

            GL.End();
        }

        private void DrawHsvAxes()
        {
            GL.LineWidth(4f);
            GL.Begin(PrimitiveType.Lines);

            DrawColoredLine(Color.White, SceneCenter, 0f, SceneCenter, SceneCenter, AxisLength, SceneCenter);          // V
            DrawColoredLine(Color.Yellow, SceneCenter, CubeSize, SceneCenter, AxisLength, CubeSize, SceneCenter);    // S
            DrawColoredLine(Color.Red, SceneCenter, CubeSize, SceneCenter, SceneCenter, CubeSize, AxisLength);       // H reference

            GL.End();
        }

        // YCbCr / YUV SLICE
        private void DrawLumaChromaSlice(Func<float, float, float, Color> convertToRgb)
        {
            const int step = 4;
            float y = _ycbcrYValue;

            GL.Begin(PrimitiveType.Quads);

            for (int x = 0; x < CubeSize; x += step)
            {
                for (int z = 0; z < CubeSize; z += step)
                {
                    int x2 = Math.Min(x + step, (int)CubeSize);
                    int z2 = Math.Min(z + step, (int)CubeSize);

                    EmitColoredVertex(convertToRgb(y, x, z), x, y, z);
                    EmitColoredVertex(convertToRgb(y, x2, z), x2, y, z);
                    EmitColoredVertex(convertToRgb(y, x2, z2), x2, y, z2);
                    EmitColoredVertex(convertToRgb(y, x, z2), x, y, z2);
                }
            }

            GL.End();
        }

        private Color YcbcrToRgb(float y255, float cb255, float cr255)
        {
            float cb = cb255 - 128f;
            float cr = cr255 - 128f;

            float r = y255 + 1.402f * cr;
            float g = y255 - 0.344136f * cb - 0.714136f * cr;
            float b = y255 + 1.772f * cb;

            return Color.FromArgb(ClampToByte(r), ClampToByte(g), ClampToByte(b));
        }

        private Color YuvToRgb(float y255, float u255, float v255)
        {
            float u = u255 - 128f;
            float v = v255 - 128f;

            float r = y255 + 1.13983f * v;
            float g = y255 - 0.39465f * u - 0.58060f * v;
            float b = y255 + 2.03211f * u;

            return Color.FromArgb(ClampToByte(r), ClampToByte(g), ClampToByte(b));
        }

        // LAB DISK
        private void DrawLabDisk()
        {
            float yPosition = _labLightness * 2.55f;
            float radius = _labChroma;

            DrawPolarDisk(
                SceneCenter,
                yPosition,
                SceneCenter,
                radius,
                24,
                CircleSegments,
                delegate (float hue, float currentRadius, float normalizedRadius)
                {
                    double angle = hue * Math.PI * 2.0;
                    float a = currentRadius * (float)Math.Cos(angle);
                    float b = currentRadius * (float)Math.Sin(angle);
                    return LabToRgb(_labLightness, a, b);
                }
            );
        }
        private void DrawLabAxes()
        {
            GL.LineWidth(4f);
            GL.Begin(PrimitiveType.Lines);

            DrawColoredLine(Color.White, SceneCenter, 0f, SceneCenter, SceneCenter, AxisLength, SceneCenter);                 // L*
            DrawColoredLine(Color.Red, SceneCenter, SceneCenter, SceneCenter, SceneCenter + 160f, SceneCenter, SceneCenter); // +a*
            DrawColoredLine(Color.Lime, SceneCenter, SceneCenter, SceneCenter, SceneCenter - 160f, SceneCenter, SceneCenter);// -a*
            DrawColoredLine(Color.Yellow, SceneCenter, SceneCenter, SceneCenter, SceneCenter, SceneCenter, SceneCenter + 160f);// +b*
            DrawColoredLine(Color.Blue, SceneCenter, SceneCenter, SceneCenter, SceneCenter, SceneCenter, SceneCenter - 160f);  // -b*

            GL.End();
        }

        private void DrawPolarDisk(
            float centerX,
            float y,
            float centerZ,
            float maxRadius,
            int radialSegments,
            int angularSegments,
            Func<float, float, float, Color> colorProvider)
        {
            GL.Begin(PrimitiveType.Quads);

            for (int r = 0; r < radialSegments; r++)
            {
                float r1 = maxRadius * r / radialSegments;
                float r2 = maxRadius * (r + 1) / radialSegments;

                for (int h = 0; h < angularSegments; h++)
                {
                    float h1 = h / (float)angularSegments;
                    float h2 = (h + 1) / (float)angularSegments;

                    EmitPolarDiskVertex(centerX, y, centerZ, r1, h1, maxRadius, colorProvider);
                    EmitPolarDiskVertex(centerX, y, centerZ, r1, h2, maxRadius, colorProvider);
                    EmitPolarDiskVertex(centerX, y, centerZ, r2, h2, maxRadius, colorProvider);
                    EmitPolarDiskVertex(centerX, y, centerZ, r2, h1, maxRadius, colorProvider);
                }
            }

            GL.End();
        }

        private void EmitPolarDiskVertex(
            float centerX,
            float y,
            float centerZ,
            float radius,
            float hue,
            float maxRadius,
            Func<float, float, float, Color> colorProvider)
        {
            double angle = hue * Math.PI * 2.0;
            float x = centerX + radius * (float)Math.Cos(angle);
            float z = centerZ + radius * (float)Math.Sin(angle);
            float normalizedRadius = maxRadius <= 0f ? 0f : radius / maxRadius;

            EmitColoredVertex(colorProvider(hue, radius, normalizedRadius), x, y, z);
        }

        // COLOR CONVERSIONS
        private Color HsvToRgb(float h, float s, float v)
        {
            h = h - (float)Math.Floor(h);

            if (s <= 0f)
            {
                int gray = ClampToByte(v * 255f);
                return Color.FromArgb(gray, gray, gray);
            }

            float sector = h * 6f;
            int i = (int)Math.Floor(sector);
            float f = sector - i;

            float p = v * (1f - s);
            float q = v * (1f - s * f);
            float t = v * (1f - s * (1f - f));

            float r;
            float g;
            float b;

            switch (i % 6)
            {
                case 0: r = v; g = t; b = p; break;
                case 1: r = q; g = v; b = p; break;
                case 2: r = p; g = v; b = t; break;
                case 3: r = p; g = q; b = v; break;
                case 4: r = t; g = p; b = v; break;
                default: r = v; g = p; b = q; break;
            }

            return Color.FromArgb(ClampToByte(r * 255f), ClampToByte(g * 255f), ClampToByte(b * 255f));
        }

        private Color LabToRgb(float l, float a, float b)
        {
            float y = (l + 16f) / 116f;
            float x = a / 500f + y;
            float z = y - b / 200f;

            x = LabPivotInverse(x);
            y = LabPivotInverse(y);
            z = LabPivotInverse(z);

            float X = 95.047f * x / 100f;
            float Y = 100.000f * y / 100f;
            float Z = 108.883f * z / 100f;

            float r = X * 3.2406f + Y * -1.5372f + Z * -0.4986f;
            float g = X * -0.9689f + Y * 1.8758f + Z * 0.0415f;
            float blue = X * 0.0557f + Y * -0.2040f + Z * 1.0570f;

            r = SrgbGammaCorrect(r);
            g = SrgbGammaCorrect(g);
            blue = SrgbGammaCorrect(blue);

            return Color.FromArgb(ClampToByte(r * 255f), ClampToByte(g * 255f), ClampToByte(blue * 255f));
        }

        private void RgbToHsv(Color color, out float h, out float s, out float v)
        {
            float r = color.R / 255f;
            float g = color.G / 255f;
            float b = color.B / 255f;

            float max = Math.Max(r, Math.Max(g, b));
            float min = Math.Min(r, Math.Min(g, b));
            float delta = max - min;

            v = max;

            if (max == 0f)
                s = 0f;
            else
                s = delta / max;

            if (delta == 0f)
            {
                h = 0f;
            }
            else if (max == r)
            {
                h = 60f * (((g - b) / delta) % 6f);
            }
            else if (max == g)
            {
                h = 60f * (((b - r) / delta) + 2f);
            }
            else
            {
                h = 60f * (((r - g) / delta) + 4f);
            }

            if (h < 0f)
                h += 360f;
        }

        private void RgbToCmyk(Color color, out float c, out float m, out float y, out float k)
        {
            float r = color.R / 255f;
            float g = color.G / 255f;
            float b = color.B / 255f;

            k = 1f - Math.Max(r, Math.Max(g, b));

            if (k >= 1f)
            {
                c = 0f;
                m = 0f;
                y = 0f;
                k = 1f;
                return;
            }

            c = (1f - r - k) / (1f - k);
            m = (1f - g - k) / (1f - k);
            y = (1f - b - k) / (1f - k);
        }

        private void RgbToYuv(Color color, out float y, out float u, out float v)
        {
            float r = color.R;
            float g = color.G;
            float b = color.B;

            y = 0.299f * r + 0.587f * g + 0.114f * b;
            u = -0.14713f * r - 0.28886f * g + 0.436f * b;
            v = 0.615f * r - 0.51499f * g - 0.10001f * b;
        }

        private void RgbToYcbcr(Color color, out float y, out float cb, out float cr)
        {
            float r = color.R;
            float g = color.G;
            float b = color.B;

            y = 0.299f * r + 0.587f * g + 0.114f * b;

            cb = 128f
                 - 0.168736f * r
                 - 0.331264f * g
                 + 0.5f * b;

            cr = 128f
                 + 0.5f * r
                 - 0.418688f * g
                 - 0.081312f * b;
        }

        private void RgbToLab(Color color, out float l, out float a, out float b)
        {
            float r = SrgbToLinear(color.R / 255f);
            float g = SrgbToLinear(color.G / 255f);
            float blue = SrgbToLinear(color.B / 255f);

            float x = r * 0.4124f + g * 0.3576f + blue * 0.1805f;
            float y = r * 0.2126f + g * 0.7152f + blue * 0.0722f;
            float z = r * 0.0193f + g * 0.1192f + blue * 0.9505f;

            x *= 100f;
            y *= 100f;
            z *= 100f;

            float xr = x / 95.047f;
            float yr = y / 100.000f;
            float zr = z / 108.883f;

            float fx = LabPivotForward(xr);
            float fy = LabPivotForward(yr);
            float fz = LabPivotForward(zr);

            l = 116f * fy - 16f;
            a = 500f * (fx - fy);
            b = 200f * (fy - fz);
        }

        private float SrgbToLinear(float value)
        {
            if (value <= 0.04045f)
                return value / 12.92f;

            return (float)Math.Pow((value + 0.055f) / 1.055f, 2.4);
        }

        private float LabPivotForward(float value)
        {
            if (value > 0.008856f)
                return (float)Math.Pow(value, 1.0 / 3.0);

            return 7.787f * value + 16f / 116f;
        }

        private float LabPivotInverse(float value)
        {
            float value3 = value * value * value;
            return value3 > 0.008856f ? value3 : (value - 16f / 116f) / 7.787f;
        }

        private float SrgbGammaCorrect(float value)
        {
            if (value <= 0.0031308f)
                return 12.92f * value;

            return 1.055f * (float)Math.Pow(value, 1.0 / 2.4) - 0.055f;
        }

        private int ClampToByte(float value)
        {
            if (value < 0f)
                return 0;

            if (value > 255f)
                return 255;

            return (int)Math.Round(value);
        }

        // MOUSE INTERACTION
        private void GlControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _isDragging = true;
                _mouseMovedWhileDragging = false;
                _lastMousePosition = e.Location;
                _dragStartPosition = e.Location;
            }
        }

        private void GlControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (!_isDragging)
                return;

            int totalDx = e.X - _dragStartPosition.X;
            int totalDy = e.Y - _dragStartPosition.Y;

            if (!_mouseMovedWhileDragging)
            {
                if (Math.Abs(totalDx) < ClickTolerance && Math.Abs(totalDy) < ClickTolerance)
                    return;

                _mouseMovedWhileDragging = true;
            }

            int dx = e.X - _lastMousePosition.X;
            int dy = e.Y - _lastMousePosition.Y;

            _rotationY += dx * 0.5f;
            _rotationX += dy * 0.5f;

            _lastMousePosition = e.Location;
            Redraw();
        }

        private void GlControl_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (!_mouseMovedWhileDragging)
                {
                    PickColorAt(e.Location);
                }
            }

            _isDragging = false;
        }

        private void GlControl_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
                _zoom += 30f;
            else
                _zoom -= 30f;

            Redraw();
        }

        // قراءة لون البكسل
        private void PickColorAt(Point mouseLocation)
        {
            if (_glControl == null)
                return;

            if (mouseLocation.X < 0 || mouseLocation.Y < 0 ||
                mouseLocation.X >= _glControl.Width ||
                mouseLocation.Y >= _glControl.Height)
                return;

            _glControl.MakeCurrent();

            RenderScene();
            GL.Flush();

            int glY = _glControl.Height - mouseLocation.Y - 1;

            byte[] pixel = new byte[4];

            GL.ReadPixels(
                mouseLocation.X,
                glY,
                1,
                1,
                OpenTK.Graphics.OpenGL.PixelFormat.Rgba,
                PixelType.UnsignedByte,
                pixel
            );

            _glControl.SwapBuffers();

            Color pickedColor = Color.FromArgb(pixel[0], pixel[1], pixel[2]);

            ShowColorValues(pickedColor);
        }

        //دالة لعرض القيم
        private void ShowColorValues(Color color)
        {
            if (selectedColorPreview != null)
                selectedColorPreview.BackColor = color;

            string hex = "#" + color.R.ToString("X2") +
                               color.G.ToString("X2") +
                               color.B.ToString("X2");

            float h, s, v;
            RgbToHsv(color, out h, out s, out v);

            float c, m, y, k;
            RgbToCmyk(color, out c, out m, out y, out k);

            float yuvY, u, yuvV;
            RgbToYuv(color, out yuvY, out u, out yuvV);

            float ycbcrY, cb, cr;
            RgbToYcbcr(color, out ycbcrY, out cb, out cr);

            float labL, labA, labB;
            RgbToLab(color, out labL, out labA, out labB);

            colorValuesBox.Text =
                hex + Environment.NewLine + Environment.NewLine +

                "RGB   → (" + color.R + ", " + color.G + ", " + color.B + ")" + Environment.NewLine +

                "HSV   → (" +
                h.ToString("0.##") + "°, " +
                (s * 100f).ToString("0.##") + "%, " +
                (v * 100f).ToString("0.##") + "%)" + Environment.NewLine +

                "CMYK  → (" +
                c.ToString("0.##") + ", " +
                m.ToString("0.##") + ", " +
                y.ToString("0.##") + ", " +
                k.ToString("0.##") + ")" + Environment.NewLine +

                "YUV   → (" +
                yuvY.ToString("0.##") + ", " +
                u.ToString("0.##") + ", " +
                yuvV.ToString("0.##") + ")" + Environment.NewLine +

                "YCbCr → (" +
                ycbcrY.ToString("0.##") + ", " +
                cb.ToString("0.##") + ", " +
                cr.ToString("0.##") + ")" + Environment.NewLine +

                "LAB   → (" +
                labL.ToString("0.##") + ", " +
                labA.ToString("0.##") + ", " +
                labB.ToString("0.##") + ")";
        }

        // DESIGNER EVENTS
        private void button1_Click_1(object sender, EventArgs e)
        {
            ResetView();
        }

        private void ResetView()
        {
            _rotationX = 25f;
            _rotationY = -35f;
            _zoom = -650f;
            Redraw();
        }
    }
}