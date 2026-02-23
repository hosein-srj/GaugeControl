using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace GaugeExample
{
    public partial class Gauge : UserControl
    {
        public Gauge()
        {
            InitializeComponent();
            Loaded += (s, e) => Redraw();
            SizeChanged += (s, e) => Redraw();
        }

        #region Dependency Properties
        public double Minimum { get => (double)GetValue(MinimumProperty); set => SetValue(MinimumProperty, value); }
        public static readonly DependencyProperty MinimumProperty =
            DependencyProperty.Register(nameof(Minimum), typeof(double), typeof(Gauge),
                new PropertyMetadata(0d, OnRedraw));

        public double Maximum { get => (double)GetValue(MaximumProperty); set => SetValue(MaximumProperty, value); }
        public static readonly DependencyProperty MaximumProperty =
            DependencyProperty.Register(nameof(Maximum), typeof(double), typeof(Gauge),
                new PropertyMetadata(100d, OnRedraw));

        public double Value { get => (double)GetValue(ValueProperty); set => SetValue(ValueProperty, value); }
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register(nameof(Value), typeof(double), typeof(Gauge),
                new PropertyMetadata(0d, OnRedraw));

        public double ScaleStartAngle { get => (double)GetValue(ScaleStartAngleProperty); set => SetValue(ScaleStartAngleProperty, value); }
        public static readonly DependencyProperty ScaleStartAngleProperty =
            DependencyProperty.Register(nameof(ScaleStartAngle), typeof(double), typeof(Gauge),
                new PropertyMetadata(180d, OnRedraw));

        public double ScaleEndAngle { get => (double)GetValue(ScaleEndAngleProperty); set => SetValue(ScaleEndAngleProperty, value); }
        public static readonly DependencyProperty ScaleEndAngleProperty =
            DependencyProperty.Register(nameof(ScaleEndAngle), typeof(double), typeof(Gauge),
                new PropertyMetadata(0d, OnRedraw));

        public Brush NeedleBrush { get => (Brush)GetValue(NeedleBrushProperty); set => SetValue(NeedleBrushProperty, value); }
        public static readonly DependencyProperty NeedleBrushProperty =
            DependencyProperty.Register(nameof(NeedleBrush), typeof(Brush), typeof(Gauge),
                new PropertyMetadata(Brushes.DarkGreen, OnRedraw));

        public Brush TickBrush { get => (Brush)GetValue(TickBrushProperty); set => SetValue(TickBrushProperty, value); }
        public static readonly DependencyProperty TickBrushProperty =
            DependencyProperty.Register(nameof(TickBrush), typeof(Brush), typeof(Gauge),
                new PropertyMetadata(Brushes.Black, OnRedraw));

        public double TickInterval { get => (double)GetValue(TickIntervalProperty); set => SetValue(TickIntervalProperty, value); }
        public static readonly DependencyProperty TickIntervalProperty =
            DependencyProperty.Register(nameof(TickInterval), typeof(double), typeof(Gauge),
                new PropertyMetadata(10d, OnRedraw));

        public double TickStartExtent { get => (double)GetValue(TickStartExtentProperty); set => SetValue(TickStartExtentProperty, value); }
        public static readonly DependencyProperty TickStartExtentProperty =
            DependencyProperty.Register(nameof(TickStartExtent), typeof(double), typeof(Gauge),
                new PropertyMetadata(0.65, OnRedraw));

        public double TickEndExtent { get => (double)GetValue(TickEndExtentProperty); set => SetValue(TickEndExtentProperty, value); }
        public static readonly DependencyProperty TickEndExtentProperty =
            DependencyProperty.Register(nameof(TickEndExtent), typeof(double), typeof(Gauge),
                new PropertyMetadata(0.72, OnRedraw));

        public double MinorTickInterval { get => (double)GetValue(MinorTickIntervalProperty); set => SetValue(MinorTickIntervalProperty, value); }
        public static readonly DependencyProperty MinorTickIntervalProperty =
            DependencyProperty.Register(nameof(MinorTickInterval), typeof(double), typeof(Gauge),
                new PropertyMetadata(0d, OnRedraw));

        public Brush MinorTickBrush { get => (Brush)GetValue(MinorTickBrushProperty); set => SetValue(MinorTickBrushProperty, value); }
        public static readonly DependencyProperty MinorTickBrushProperty =
            DependencyProperty.Register(nameof(MinorTickBrush), typeof(Brush), typeof(Gauge),
                new PropertyMetadata(Brushes.Black, OnRedraw));

        public double MinorTickStartExtent { get => (double)GetValue(MinorTickStartExtentProperty); set => SetValue(MinorTickStartExtentProperty, value); }
        public static readonly DependencyProperty MinorTickStartExtentProperty =
            DependencyProperty.Register(nameof(MinorTickStartExtent), typeof(double), typeof(Gauge),
                new PropertyMetadata(0.65, OnRedraw));

        public double MinorTickEndExtent { get => (double)GetValue(MinorTickEndExtentProperty); set => SetValue(MinorTickEndExtentProperty, value); }
        public static readonly DependencyProperty MinorTickEndExtentProperty =
            DependencyProperty.Register(nameof(MinorTickEndExtent), typeof(double), typeof(Gauge),
                new PropertyMetadata(0.69, OnRedraw));

        public Brush LabelFontBrush { get => (Brush)GetValue(LabelFontBrushProperty); set => SetValue(LabelFontBrushProperty, value); }
        public static readonly DependencyProperty LabelFontBrushProperty =
            DependencyProperty.Register(nameof(LabelFontBrush), typeof(Brush), typeof(Gauge),
                new PropertyMetadata(Brushes.DarkGreen, OnRedraw));

        public double LabelExtent { get => (double)GetValue(LabelExtentProperty); set => SetValue(LabelExtentProperty, value); }
        public static readonly DependencyProperty LabelExtentProperty =
            DependencyProperty.Register(nameof(LabelExtent), typeof(double), typeof(Gauge),
                new PropertyMetadata(0.88, OnRedraw));

        public double LabelFontSize { get => (double)GetValue(LabelFontSizeProperty); set => SetValue(LabelFontSizeProperty, value); }
        public static readonly DependencyProperty LabelFontSizeProperty =
            DependencyProperty.Register(nameof(LabelFontSize), typeof(double), typeof(Gauge),
                new PropertyMetadata(13d, OnRedraw));

        public Brush RangeBrush { get => (Brush)GetValue(RangeBrushProperty); set => SetValue(RangeBrushProperty, value); }
        public static readonly DependencyProperty RangeBrushProperty =
            DependencyProperty.Register(nameof(RangeBrush), typeof(Brush), typeof(Gauge),
                new PropertyMetadata(Brushes.Red, OnRedraw));

        public double RangeInnerStartExtent { get => (double)GetValue(RangeInnerStartExtentProperty); set => SetValue(RangeInnerStartExtentProperty, value); }
        public static readonly DependencyProperty RangeInnerStartExtentProperty =
            DependencyProperty.Register(nameof(RangeInnerStartExtent), typeof(double), typeof(Gauge),
                new PropertyMetadata(0.35, OnRedraw));

        public double RangeOuterStartExtent { get => (double)GetValue(RangeOuterStartExtentProperty); set => SetValue(RangeOuterStartExtentProperty, value); }
        public static readonly DependencyProperty RangeOuterStartExtentProperty =
            DependencyProperty.Register(nameof(RangeOuterStartExtent), typeof(double), typeof(Gauge),
                new PropertyMetadata(0.40, OnRedraw));

        public double RangeInnerEndExtent { get => (double)GetValue(RangeInnerEndExtentProperty); set => SetValue(RangeInnerEndExtentProperty, value); }
        public static readonly DependencyProperty RangeInnerEndExtentProperty =
            DependencyProperty.Register(nameof(RangeInnerEndExtent), typeof(double), typeof(Gauge),
                new PropertyMetadata(0.35, OnRedraw));

        public double RangeOuterEndExtent { get => (double)GetValue(RangeOuterEndExtentProperty); set => SetValue(RangeOuterEndExtentProperty, value); }
        public static readonly DependencyProperty RangeOuterEndExtentProperty =
            DependencyProperty.Register(nameof(RangeOuterEndExtent), typeof(double), typeof(Gauge),
                new PropertyMetadata(0.40, OnRedraw));

        public Brush NeedlePivotBrush { get => (Brush)GetValue(NeedlePivotBrushProperty); set => SetValue(NeedlePivotBrushProperty, value); }
        public static readonly DependencyProperty NeedlePivotBrushProperty =
            DependencyProperty.Register(nameof(NeedlePivotBrush), typeof(Brush), typeof(Gauge),
                new PropertyMetadata(Brushes.DarkGreen, OnRedraw));

        public Brush NeedlePivotOutlineBrush { get => (Brush)GetValue(NeedlePivotOutlineBrushProperty); set => SetValue(NeedlePivotOutlineBrushProperty, value); }
        public static readonly DependencyProperty NeedlePivotOutlineBrushProperty =
            DependencyProperty.Register(nameof(NeedlePivotOutlineBrush), typeof(Brush), typeof(Gauge),
                new PropertyMetadata(Brushes.DarkGreen, OnRedraw));

        public double NeedlePivotEndExtent { get => (double)GetValue(NeedlePivotEndExtentProperty); set => SetValue(NeedlePivotEndExtentProperty, value); }
        public static readonly DependencyProperty NeedlePivotEndExtentProperty =
            DependencyProperty.Register(nameof(NeedlePivotEndExtent), typeof(double), typeof(Gauge),
                new PropertyMetadata(0.15, OnRedraw));

        public double NeedleEndExtent { get => (double)GetValue(NeedleEndExtentProperty); set => SetValue(NeedleEndExtentProperty, value); }
        public static readonly DependencyProperty NeedleEndExtentProperty =
            DependencyProperty.Register(nameof(NeedleEndExtent), typeof(double), typeof(Gauge),
                new PropertyMetadata(0.8, OnRedraw));

        public double NeedleEndWidth { get => (double)GetValue(NeedleEndWidthProperty); set => SetValue(NeedleEndWidthProperty, value); }
        public static readonly DependencyProperty NeedleEndWidthProperty =
            DependencyProperty.Register(nameof(NeedleEndWidth), typeof(double), typeof(Gauge),
                new PropertyMetadata(1.0, OnRedraw));

        public double NeedleCircleRadius
        {
            get => (double)GetValue(NeedleCircleRadiusProperty);
            set => SetValue(NeedleCircleRadiusProperty, value);
        }
        public static readonly DependencyProperty NeedleCircleRadiusProperty =
            DependencyProperty.Register(nameof(NeedleCircleRadius), typeof(double), typeof(Gauge),
                new PropertyMetadata(0.0, OnRedraw));
        public double RangeScaleFactor
        {
            get => (double)GetValue(RangeScaleFactorProperty);
            set => SetValue(NeedleCircleRadiusProperty, value);
        }
        public static readonly DependencyProperty RangeScaleFactorProperty =
            DependencyProperty.Register(nameof(RangeScaleFactor), typeof(double), typeof(Gauge),
                new PropertyMetadata(0.0, OnRedraw));
        public bool InvertedRange
        {
            get => (bool)GetValue(InvertedRangeProperty);
            set => SetValue(InvertedRangeProperty, value);
        }

        public static readonly DependencyProperty InvertedRangeProperty =
            DependencyProperty.Register(nameof(InvertedRange), typeof(bool), typeof(Gauge),
                new PropertyMetadata(false, OnRedraw));
        private static void OnRedraw(DependencyObject d, DependencyPropertyChangedEventArgs e)
            => (d as Gauge)?.Redraw();

        public double ValueExtent
        {
            get => (double)GetValue(ValueExtentProperty);
            set => SetValue(ValueExtentProperty, value);
        }
        public static readonly DependencyProperty ValueExtentProperty =
            DependencyProperty.Register(nameof(ValueExtent), typeof(double), typeof(Gauge),
                new PropertyMetadata(0.25, OnRedraw));

        public string ValueFormatString
        {
            get => (string)GetValue(ValueFormatStringProperty);
            set => SetValue(ValueFormatStringProperty, value);
        }
        public static readonly DependencyProperty ValueFormatStringProperty =
            DependencyProperty.Register(nameof(ValueFormatString), typeof(string), typeof(Gauge),
                new PropertyMetadata("{0:F0}", OnRedraw));

        public string PostfixValue
        {
            get => (string)GetValue(PostfixValueProperty);
            set => SetValue(PostfixValueProperty, value);
        }
        public static readonly DependencyProperty PostfixValueProperty =
            DependencyProperty.Register(nameof(PostfixValue), typeof(string), typeof(Gauge),
                new PropertyMetadata("", OnRedraw));

        public Brush ValueFontBrush
        {
            get => (Brush)GetValue(ValueFontBrushProperty);
            set => SetValue(ValueFontBrushProperty, value);
        }
        public static readonly DependencyProperty ValueFontBrushProperty =
            DependencyProperty.Register(nameof(ValueFontBrush), typeof(Brush), typeof(Gauge),
                new PropertyMetadata(Brushes.Black, OnRedraw));

        public string ValueFontFamily
        {
            get => (string)GetValue(ValueFontFamilyProperty);
            set => SetValue(ValueFontFamilyProperty, value);
        }
        public static readonly DependencyProperty ValueFontFamilyProperty =
            DependencyProperty.Register(nameof(ValueFontFamily), typeof(string), typeof(Gauge),
                new PropertyMetadata("Arial", OnRedraw));

        public double ValueFontSize
        {
            get => (double)GetValue(ValueFontSizeProperty);
            set => SetValue(ValueFontSizeProperty, value);
        }
        public static readonly DependencyProperty ValueFontSizeProperty =
            DependencyProperty.Register(nameof(ValueFontSize), typeof(double), typeof(Gauge),
                new PropertyMetadata(16.0, OnRedraw));

        public FontWeight ValueFontWeight
        {
            get => (FontWeight)GetValue(ValueFontWeightProperty);
            set => SetValue(ValueFontWeightProperty, value);
        }
        public static readonly DependencyProperty ValueFontWeightProperty =
            DependencyProperty.Register(nameof(ValueFontWeight), typeof(FontWeight), typeof(Gauge),
                new PropertyMetadata(FontWeights.Normal, OnRedraw));

        public string ValueLocation
        {
            get => (string)GetValue(ValueLocationProperty);
            set => SetValue(ValueLocationProperty, value);
        }
        public static readonly DependencyProperty ValueLocationProperty =
            DependencyProperty.Register(nameof(ValueLocation), typeof(string), typeof(Gauge),
                new PropertyMetadata("BottomCenter", OnRedraw));

        public string LabelFontFamily
        {
            get => (string)GetValue(LabelFontFamilyProperty);
            set => SetValue(LabelFontFamilyProperty, value);
        }
        public static readonly DependencyProperty LabelFontFamilyProperty =
            DependencyProperty.Register(nameof(LabelFontFamily), typeof(string), typeof(Gauge),
                new PropertyMetadata("Arial", OnRedraw));

        public FontWeight LabelFontWeight
        {
            get => (FontWeight)GetValue(LabelFontWeightProperty);
            set => SetValue(LabelFontWeightProperty, value);
        }
        public static readonly DependencyProperty LabelFontWeightProperty =
            DependencyProperty.Register(nameof(LabelFontWeight), typeof(FontWeight), typeof(Gauge),
                new PropertyMetadata(FontWeights.Normal, OnRedraw));
        public string LabelFormatString
        {
            get => (string)GetValue(LabelFormatStringProperty);
            set => SetValue(LabelFormatStringProperty, value);
        }
        public static readonly DependencyProperty LabelFormatStringProperty =
            DependencyProperty.Register(nameof(LabelFormatString), typeof(string), typeof(Gauge),
                new PropertyMetadata("{0:F0}", OnRedraw));
        public double TickStrokeWidth
        {
            get => (double)GetValue(TickStrokeWidthProperty);
            set => SetValue(TickStrokeWidthProperty, value);
        }
        public static readonly DependencyProperty TickStrokeWidthProperty =
            DependencyProperty.Register(nameof(TickStrokeWidth), typeof(double), typeof(Gauge),
                new PropertyMetadata(1.0, OnRedraw));

        public double MinorTickStrokeWidth
        {
            get => (double)GetValue(MinorTickStrokeWidthProperty);
            set => SetValue(MinorTickStrokeWidthProperty, value);
        }
        public static readonly DependencyProperty MinorTickStrokeWidthProperty =
            DependencyProperty.Register(nameof(MinorTickStrokeWidth), typeof(double), typeof(Gauge),
                new PropertyMetadata(1.0, OnRedraw));
        #endregion

        private void Redraw()
        {
            if (!IsLoaded) return;
            RootCanvas.Children.Clear();

            double radius = Math.Min(ActualWidth, ActualHeight) / 2.0;
            Point center = new Point(ActualWidth / 2, ActualHeight / 2);

            DrawRange(center, radius);
            DrawTicks(center, radius);
            DrawNeedle(center, radius);
            DrawValueText(center, radius);
        }

        private void DrawValueText(Point center, double radius)
        {
            string text = string.Format(ValueFormatString, Value) + " " + PostfixValue;
            var ft = new FormattedText(
                text,
                System.Globalization.CultureInfo.CurrentCulture,
                FlowDirection.LeftToRight,
                new Typeface(new FontFamily(ValueFontFamily), FontStyles.Normal, ValueFontWeight, FontStretches.Normal),
                ValueFontSize,
                ValueFontBrush,
                VisualTreeHelper.GetDpi(this).PixelsPerDip
            );

            // Determine location
            Point pos = center;
            double offset = radius * ValueExtent;

            switch (ValueLocation)
            {
                case "BottomCenter":
                    pos.Y += offset;
                    pos.X -= ft.Width / 2;
                    pos.Y -= ft.Height / 2;
                    break;
                case "TopCenter":
                    pos.Y -= offset + ft.Height;
                    pos.X -= ft.Width / 2;
                    break;
                case "Center":
                    pos.X -= ft.Width / 2;
                    pos.Y -= ft.Height / 2;
                    break;
                case "LeftCenter":
                    pos.X -= radius * ValueExtent + ft.Width;
                    pos.Y -= ft.Height / 2;
                    break;
                case "RightCenter":
                    pos.X += radius * ValueExtent;
                    pos.Y -= ft.Height / 2;
                    break;
                default:
                    pos.Y += offset; // fallback
                    pos.X -= ft.Width / 2;
                    pos.Y -= ft.Height / 2;
                    break;
            }

            var geo = ft.BuildGeometry(new Point(pos.X, pos.Y));
            RootCanvas.Children.Add(new Path { Data = geo, Fill = ValueFontBrush });
        }

        private void DrawRange(Point center, double radius)
        {
            double range = Maximum - Minimum;
            if (range <= 0) return;

            // Compute start/end angles (here full gauge range; you can add RangeStart/End values if desired)
            double startAngle = ScaleStartAngle ;
            double endAngle = ScaleEndAngle;
            if(InvertedRange)
            {
                startAngle = ScaleEndAngle;
                endAngle = ScaleStartAngle ;
            }

            PathFigure fig = new PathFigure();
            Point p1 = PointOnCircle(center, radius * RangeOuterStartExtent, startAngle);
            fig.StartPoint = p1;

            ArcSegment arcOuter = new ArcSegment(
                PointOnCircle(center, radius * RangeOuterEndExtent, endAngle),
                new Size(radius * RangeOuterEndExtent, radius * RangeOuterEndExtent),
                0, false, SweepDirection.Counterclockwise, true);

            LineSegment lineInner1 = new LineSegment(PointOnCircle(center, radius * RangeInnerEndExtent, endAngle), true);

            ArcSegment arcInner = new ArcSegment(
                PointOnCircle(center, radius * RangeInnerStartExtent, startAngle),
                new Size(radius * RangeInnerStartExtent, radius * RangeInnerStartExtent),
                0, false, SweepDirection.Clockwise, true);

            fig.Segments.Add(arcOuter);
            fig.Segments.Add(lineInner1);
            fig.Segments.Add(arcInner);
            fig.IsClosed = true;

            PathGeometry geo = new PathGeometry();
            geo.Figures.Add(fig);

            var path = new Path { Data = geo, Fill = RangeBrush, StrokeThickness = 0 };
            RootCanvas.Children.Add(path);
        }

        private void DrawTicks(Point center, double radius)
        {
            double range = Maximum - Minimum;
            if (range <= 0) return;

            for (double val = Minimum; val <= Maximum + 0.0001; val += TickInterval)
            {
                
                double ratio = (val - Minimum) / range;
                double angle = ScaleStartAngle - (ScaleStartAngle - ScaleEndAngle) * ratio;
                DrawTick(center, radius, angle, TickStartExtent, TickEndExtent, TickBrush, TickStrokeWidth);

                // Label
                TextBlock label = new TextBlock
                {
                    Text = string.Format(LabelFormatString, val / RangeScaleFactor),
                    Foreground = LabelFontBrush,
                    FontSize = LabelFontSize,
                    FontFamily = new FontFamily(LabelFontFamily),
                    FontWeight = LabelFontWeight
                };
                label.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
                Size s = label.DesiredSize;
                Point lp = PointOnCircle(center, radius * LabelExtent, angle);
                Canvas.SetLeft(label, lp.X - s.Width / 2);
                Canvas.SetTop(label, lp.Y - s.Height / 2);
                RootCanvas.Children.Add(label);
            }

            if (MinorTickInterval > 0)
            {
                for (double val = Minimum; val <= Maximum + 0.0001; val += MinorTickInterval)
                {
                    if (Math.Abs((val - Minimum) % TickInterval) < 1e-6) continue;
                    double ratio = (val - Minimum) / range;
                    double angle = ScaleStartAngle - (ScaleStartAngle - ScaleEndAngle) * ratio;
                    DrawTick(center, radius, angle, MinorTickStartExtent, MinorTickEndExtent, MinorTickBrush, MinorTickStrokeWidth);
                }
            }
        }

        private void DrawTick(Point c, double r, double angle, double inner, double outer, Brush b, double w)
        {
            Point p1 = PointOnCircle(c, r * inner, angle);
            Point p2 = PointOnCircle(c, r * outer, angle);
            RootCanvas.Children.Add(new Line { X1 = p1.X, Y1 = p1.Y, X2 = p2.X, Y2 = p2.Y, Stroke = b, StrokeThickness = w });
        }

        private void DrawNeedle(Point center, double radius)
        {
            double ratio = (Value - Minimum) / (Maximum - Minimum);
            ratio = Math.Max(0, Math.Min(1, ratio));
            double angle = ScaleStartAngle - (ScaleStartAngle - ScaleEndAngle) * ratio;

            // Needle geometry: triangle pointing outward
            double pivotRadius = radius * NeedleCircleRadius;
            double needleLength = radius * NeedleEndExtent;
            double halfWidth = NeedleEndWidth * 3; // widen visually (you can tune)

            // Compute base points of triangle
            double angleRad = angle * Math.PI / 180;
            double leftAngle = angleRad + Math.PI / 2;
            double rightAngle = angleRad - Math.PI / 2;

            Point tip = new Point(center.X + needleLength * Math.Cos(angleRad),
                                  center.Y - needleLength * Math.Sin(angleRad));
            Point left = new Point(center.X + halfWidth * Math.Cos(leftAngle),
                                   center.Y - halfWidth * Math.Sin(leftAngle));
            Point right = new Point(center.X + halfWidth * Math.Cos(rightAngle),
                                    center.Y - halfWidth * Math.Sin(rightAngle));

            // Needle shape
            var needleFigure = new PathFigure { StartPoint = left };
            needleFigure.Segments.Add(new LineSegment(tip, true));
            needleFigure.Segments.Add(new LineSegment(right, true));
            needleFigure.IsClosed = true;

            var needleGeo = new PathGeometry();
            needleGeo.Figures.Add(needleFigure);

            var needlePath = new Path
            {
                Data = needleGeo,
                Fill = NeedleBrush,
                Stroke = NeedleBrush,
                StrokeThickness = 1
            };

            RootCanvas.Children.Add(needlePath);

            // Pivot (circle in center)
            double pivotSize = pivotRadius * 2;
            var pivot = new Ellipse
            {
                Width = pivotSize,
                Height = pivotSize,
                Fill = NeedlePivotBrush,
                Stroke = NeedlePivotOutlineBrush,
                StrokeThickness = 1,
                RenderTransform = new TranslateTransform(center.X - pivotRadius, center.Y - pivotRadius)
            };
            RootCanvas.Children.Add(pivot);
        }

        private Point PointOnCircle(Point center, double radius, double angleDegrees)
        {
            double a = angleDegrees * Math.PI / 180.0;
            return new Point(center.X + radius * Math.Cos(a), center.Y - radius * Math.Sin(a));
        }
    }
}
