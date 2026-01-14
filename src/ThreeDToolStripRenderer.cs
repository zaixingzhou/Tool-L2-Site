using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace LANDIS_II_Site
{
    // Stronger 3D look for ToolStrip items
    public class ThreeDToolStripRenderer : ToolStripProfessionalRenderer
    {
        protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
        {
            // stronger gradient for strip background
            using (var brush = new LinearGradientBrush(e.AffectedBounds,
                                                       Color.FromArgb(245, 247, 250),
                                                       Color.FromArgb(215, 225, 235),
                                                       90f))
            {
                e.Graphics.FillRectangle(brush, e.AffectedBounds);
            }

            // subtle top highlight and bottom shadow to give strip depth
            using (var top = new Pen(Color.FromArgb(180, 200, 220)))
                e.Graphics.DrawLine(top, e.AffectedBounds.Left, e.AffectedBounds.Top, e.AffectedBounds.Right, e.AffectedBounds.Top);

            using (var bottom = new Pen(Color.FromArgb(150, 170, 190)))
                e.Graphics.DrawLine(bottom, e.AffectedBounds.Left, e.AffectedBounds.Bottom - 1, e.AffectedBounds.Right, e.AffectedBounds.Bottom - 1);
        }

        protected override void OnRenderButtonBackground(ToolStripItemRenderEventArgs e)
        {
            var g = e.Graphics;
            var item = e.Item;

            // nothing to draw for separators or non-rectangular items
            if (item.Bounds.Width <= 0 || item.Bounds.Height <= 0) return;

                var rect = new Rectangle(Point.Empty, item.Bounds.Size);

            // smoothing for nicer rounded / bevel drawing
            var oldMode = g.SmoothingMode;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            bool pressed = (item is ToolStripButton btn && btn.Checked) || item.Pressed;
            bool hovered = item.Selected && !pressed;

            // outer drop shadow (very subtle)
            using (var shadowBrush = new SolidBrush(Color.FromArgb(25, 0, 0, 0)))
            {
                var shadowRect = rect;
                shadowRect.Offset(0, 1);
                g.FillRectangle(shadowBrush, shadowRect);
            }

            if (pressed)
            {
                // inset (pressed) gradient: darker center
                using (var b = new LinearGradientBrush(rect, Color.FromArgb(170, 190, 205), Color.FromArgb(140, 160, 175), 90f))
                {
                    g.FillRectangle(b, rect);
                }

                // inner highlight at bottom edge to emphasize inset
                using (var pen = new Pen(Color.FromArgb(140, 160, 180)))
                {
                    g.DrawLine(pen, rect.Left + 1, rect.Bottom - 2, rect.Right - 2, rect.Bottom - 2);
                }

                // dark border to reinforce pressed bezel
                ControlPaint.DrawBorder(g, rect, Color.FromArgb(80, 100, 120), ButtonBorderStyle.Solid);
            }
            else if (hovered)
            {
                // highlighted gradient for hover
                using (var b = new LinearGradientBrush(rect, Color.FromArgb(255, 255, 255), Color.FromArgb(210, 230, 245), 90f))
                {
                    g.FillRectangle(b, rect);
                }

                // top highlight line
                using (var pen = new Pen(Color.FromArgb(220, 240, 255)))
                {
                    g.DrawLine(pen, rect.Left + 1, rect.Top + 1, rect.Right - 2, rect.Top + 1);
                }

                // bottom shadow line
                using (var pen = new Pen(Color.FromArgb(160, 180, 200)))
                {
                    g.DrawLine(pen, rect.Left + 1, rect.Bottom - 2, rect.Right - 2, rect.Bottom - 2);
                }

                // stronger outer border
                ControlPaint.DrawBorder(g, rect, Color.FromArgb(100, 125, 150), ButtonBorderStyle.Solid);
            }
            else
            {
                // normal subtle bevel gradient
                using (var b = new LinearGradientBrush(rect, Color.FromArgb(250, 250, 250), Color.FromArgb(240, 245, 250), 90f))
                {
                    g.FillRectangle(b, rect);
                }

                // top very light highlight
                using (var pen = new Pen(Color.FromArgb(255, 255, 255, 200)))
                {
                    g.DrawLine(pen, rect.Left + 1, rect.Top + 1, rect.Right - 2, rect.Top + 1);
                }

                // faint bottom shadow
                using (var pen = new Pen(Color.FromArgb(220, 230, 240)))
                {
                    g.DrawLine(pen, rect.Left + 1, rect.Bottom - 2, rect.Right - 2, rect.Bottom - 2);
                }

                // thin soft border
                ControlPaint.DrawBorder(g, rect, Color.FromArgb(200, 210, 220), ButtonBorderStyle.Solid);
            }

            // restore smoothing setting
            g.SmoothingMode = oldMode;

            // NOTE:
            // Do NOT call base.OnRenderButtonBackground here — base will also draw backgrounds.
            // The text/image will be drawn by the normal ToolStrip rendering pipeline after this.
        }
    }
}