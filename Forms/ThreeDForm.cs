using System;
using System.Drawing;
using System.Windows.Forms;

using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

using PixelLab.Services.Rendering;

namespace PixelLab
{
    public partial class ThreeDForm : Form
    {
        private readonly ColorSpaceRenderer _renderer = new ColorSpaceRenderer();
        
        private GLControl _glControl;

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

            _renderer.CurrentMode = (ColorSpaceMode)Enum.Parse(typeof(ColorSpaceMode), selectedMode);

            UpdateControlsVisibility();
            Redraw();
        }

        private void TrackBarBlack_Scroll(object sender, EventArgs e)
        {
            _renderer.KValue = trackBarBlack.Value / 100.0f;
            BlackValue.Text = "K = " + trackBarBlack.Value + "%";
            Redraw();
        }

        private void TrackBarLuma_Scroll(object sender, EventArgs e)
        {
            _renderer.LumaValue = trackBarLuma.Value;
            LumaValue.Text = "Y = " + trackBarLuma.Value;
            Redraw();
        }

        private void TrackBarLabLightness_Scroll(object sender, EventArgs e)
        {
            _renderer.LabLightness = trackBarLabLightness.Value;
            LabLightnessValue.Text = "L* = " + trackBarLabLightness.Value;
            Redraw();
        }

        private void TrackBarLabChroma_Scroll(object sender, EventArgs e)
        {
            _renderer.LabChroma = trackBarLabChroma.Value;
            LabChromaValue.Text = "C* = " + trackBarLabChroma.Value;
            Redraw();
        }

        private void UpdateControlsVisibility()
        {
            bool isCmyk = _renderer.CurrentMode == ColorSpaceMode.CMYK;
            bool usesLumaSlider = _renderer.CurrentMode == ColorSpaceMode.YCbCr ||
                                  _renderer.CurrentMode == ColorSpaceMode.YUV;
            bool isLab = _renderer.CurrentMode == ColorSpaceMode.LAB;

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

        private void SetupViewport()
        {
            if (_glControl == null)
                return;

            _renderer.SetupViewport(
                _glControl.ClientSize.Width,
                _glControl.ClientSize.Height
            );
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

        

        private void GlControl_Paint(object sender, PaintEventArgs e)
        {
            _renderer.RenderScene();
            _glControl.SwapBuffers();
        }

        // DRAWING HELPERS
        private void Redraw()
        {
            if (_glControl != null)
                _glControl.Invalidate();
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

            _renderer.RotationY += dx * 0.5f;
            _renderer.RotationX += dy * 0.5f;

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
                _renderer.Zoom += 30f;
            else
                _renderer.Zoom -= 30f;

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

            _renderer.RenderScene();
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
            ColorConversionService.RgbToHsv(color, out h, out s, out v);

            float c, m, y, k;
            ColorConversionService.RgbToCmyk(color, out c, out m, out y, out k);

            float yuvY, u, yuvV;
            ColorConversionService.RgbToYuv(color, out yuvY, out u, out yuvV);

            float ycbcrY, cb, cr;
            ColorConversionService.RgbToYcbcr(color, out ycbcrY, out cb, out cr);

            float labL, labA, labB;
            ColorConversionService.RgbToLab(color, out labL, out labA, out labB);

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
            _renderer.RotationX = 25f;
            _renderer.RotationY = -35f;
            _renderer.Zoom = -650f;
            Redraw();
        }
    }
}