using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

using OpenTK;
using OpenTK.Graphics.OpenGL;

using DrawingPixelFormat = System.Drawing.Imaging.PixelFormat;
using GLPixelFormat = OpenTK.Graphics.OpenGL.PixelFormat;


namespace PixelLab.Services.Rendering
{

    public class ColorSpaceRenderer
    {
        private const float CubeSize = 255f;
        private const float SceneCenter = CubeSize / 2f;
        private const float AxisLength = 320f;
        private const int CircleSegments = 120;

        public ColorSpaceMode CurrentMode { get; set; } = ColorSpaceMode.RGB;

        public float KValue { get; set; } = 0.0f;
        public float LumaValue { get; set; } = 128f;
        public float LabLightness { get; set; } = 50f;
        public float LabChroma { get; set; } = 80f;

        public float RotationX { get; set; } = 25f;
        public float RotationY { get; set; } = -35f;
        public float Zoom { get; set; } = -650f;

        public void SetupViewport(int width, int height)
        {
            if (height == 0)
                return;

            GL.Viewport(0, 0, width, height);

            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();

            double aspect = width / (double)height;

            Matrix4 perspective = Matrix4.CreatePerspectiveFieldOfView(
                MathHelper.DegreesToRadians(45f),
                (float)aspect,
                1f,
                2000f
            );

            GL.LoadMatrix(ref perspective);
            GL.MatrixMode(MatrixMode.Modelview);
        }

        public void RenderScene()
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();

            GL.Translate(0f, 0f, Zoom);
            GL.Rotate(RotationX, 1f, 0f, 0f);
            GL.Rotate(RotationY, 0f, 1f, 0f);
            GL.Translate(-SceneCenter, -SceneCenter, -SceneCenter);

            DrawCurrentColorSpace();
        }

        public void ResetView()
        {
            RotationX = 25f;
            RotationY = -35f;
            Zoom = -650f;
        }

        public void DrawCurrentColorSpace()
        {
            switch (CurrentMode)
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
                    DrawLumaChromaSlice(ColorConversionService.YcbcrToRgb);
                    DrawHorizontalSquareFrame(LumaValue);
                    DrawAxes(Color.DeepSkyBlue, Color.White, Color.OrangeRed);
                    DrawAxisLabels(
                        "Cb", Color.DeepSkyBlue,
                        "Y", Color.White,
                        "Cr", Color.OrangeRed
                    );
                    break;

                case ColorSpaceMode.YUV:
                    DrawLumaChromaSlice(ColorConversionService.YuvToRgb);
                    DrawHorizontalSquareFrame(LumaValue);
                    DrawAxes(Color.DeepSkyBlue, Color.White, Color.OrangeRed);
                    DrawAxisLabels(
                        "U", Color.DeepSkyBlue,
                        "Y", Color.White,
                        "V", Color.OrangeRed
                    );
                    break;

                case ColorSpaceMode.LAB:
                    DrawLabDisk();
                    DrawCircleFrame(SceneCenter, LabLightness * 2.55f, SceneCenter, LabChroma);
                    DrawLabAxes();
                    DrawLabAxisLabels();
                    break;
            }
        }

        public void SetOpenGlColor(Color color)
        {
            GL.Color3(color.R / 255f, color.G / 255f, color.B / 255f);
        }

        public void EmitColoredVertex(Color color, float x, float y, float z)
        {
            SetOpenGlColor(color);
            GL.Vertex3(x, y, z);
        }

        public void DrawLine(float x1, float y1, float z1, float x2, float y2, float z2)
        {
            GL.Vertex3(x1, y1, z1);
            GL.Vertex3(x2, y2, z2);
        }

        public void DrawColoredLine(Color color, float x1, float y1, float z1, float x2, float y2, float z2)
        {
            SetOpenGlColor(color);
            DrawLine(x1, y1, z1, x2, y2, z2);
        }

        public void DrawAxes(Color xAxisColor, Color yAxisColor, Color zAxisColor)
        {
            GL.LineWidth(4f);
            GL.Begin(PrimitiveType.Lines);

            DrawColoredLine(xAxisColor, 0f, 0f, 0f, AxisLength, 0f, 0f);
            DrawColoredLine(yAxisColor, 0f, 0f, 0f, 0f, AxisLength, 0f);
            DrawColoredLine(zAxisColor, 0f, 0f, 0f, 0f, 0f, AxisLength);

            GL.End();
        }

        public void DrawText3D(string text, float x, float y, float z, Color color)
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

        public void DrawAxisLabels(
            string xLabel, Color xColor,
            string yLabel, Color yColor,
            string zLabel, Color zColor)
        {
            DrawText3D(xLabel, AxisLength + 10f, 0f, 0f, xColor);
            DrawText3D(yLabel, 0f, AxisLength + 10f, 0f, yColor);
            DrawText3D(zLabel, 0f, 0f, AxisLength + 10f, zColor);
        }

        public void DrawHsvAxisLabels()
        {
            DrawText3D("V", SceneCenter + 8f, AxisLength + 10f, SceneCenter, Color.White);
            DrawText3D("S", AxisLength + 10f, CubeSize, SceneCenter, Color.Yellow);
            DrawText3D("H", SceneCenter, CubeSize, AxisLength + 10f, Color.Red);
        }

        public void DrawLabAxisLabels()
        {
            DrawText3D("L*", SceneCenter + 8f, AxisLength + 10f, SceneCenter, Color.White);

            DrawText3D("+a*", SceneCenter + 170f, SceneCenter, SceneCenter, Color.Red);
            DrawText3D("-a*", SceneCenter - 205f, SceneCenter, SceneCenter, Color.Lime);

            DrawText3D("+b*", SceneCenter, SceneCenter, SceneCenter + 170f, Color.Yellow);
            DrawText3D("-b*", SceneCenter, SceneCenter, SceneCenter - 205f, Color.Blue);
        }

        public void DrawCircleFrame(float centerX, float y, float centerZ, float radius)
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

        public void DrawHorizontalSquareFrame(float y)
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
        public void DrawColorCube(Action<float, float, float> setVertexColorAndPosition)
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

        public void DrawColorFace(
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

        public void SetVertexWithRgbColor(float r, float g, float b)
        {
            GL.Color3(r / CubeSize, g / CubeSize, b / CubeSize);
            GL.Vertex3(r, g, b);
        }

        public void SetVertexWithCmykColor(float c255, float m255, float y255)
        {
            float c = c255 / CubeSize;
            float m = m255 / CubeSize;
            float y = y255 / CubeSize;

            float r = (1f - c) * (1f - KValue);
            float g = (1f - m) * (1f - KValue);
            float b = (1f - y) * (1f - KValue);

            GL.Color3(r, g, b);
            GL.Vertex3(c255, m255, y255);
        }

        public void DrawCubeEdges()
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
        public void DrawHsvCone()
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
                    return ColorConversionService.HsvToRgb(hue, normalizedRadius, 1f);
                }
            );
        }

        public void DrawHsvConeSide(int hueSegments)
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

                EmitColoredVertex(ColorConversionService.HsvToRgb(h1, 1f, 1f), x1, CubeSize, z1);
                EmitColoredVertex(ColorConversionService.HsvToRgb(h2, 1f, 1f), x2, CubeSize, z2);
            }

            GL.End();
        }

        public void DrawHsvAxes()
        {
            GL.LineWidth(4f);
            GL.Begin(PrimitiveType.Lines);

            DrawColoredLine(Color.White, SceneCenter, 0f, SceneCenter, SceneCenter, AxisLength, SceneCenter);          // V
            DrawColoredLine(Color.Yellow, SceneCenter, CubeSize, SceneCenter, AxisLength, CubeSize, SceneCenter);    // S
            DrawColoredLine(Color.Red, SceneCenter, CubeSize, SceneCenter, SceneCenter, CubeSize, AxisLength);       // H reference

            GL.End();
        }

        // YCbCr / YUV SLICE
        public void DrawLumaChromaSlice(Func<float, float, float, Color> convertToRgb)
        {
            const int step = 4;
            float y = LumaValue;

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
        // LAB DISK
        public void DrawLabDisk()
        {
            float yPosition = LabLightness * 2.55f;
            float radius = LabChroma;

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
                    return ColorConversionService.LabToRgb(LabLightness, a, b);
                }
            );
        }
        public void DrawLabAxes()
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

        public void DrawPolarDisk(
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

        public void EmitPolarDiskVertex(
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

    }
}
