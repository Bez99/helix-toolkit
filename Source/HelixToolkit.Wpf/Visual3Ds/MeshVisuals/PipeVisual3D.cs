﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PipeVisual3D.cs" company="Helix 3D Toolkit">
//   http://helixtoolkit.codeplex.com, license: MIT
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace HelixToolkit.Wpf
{
    using System.Windows;
    using System.Windows.Media.Media3D;

    /// <summary>
    /// A visual element that shows a pipe between two points.
    /// </summary>
    public class PipeVisual3D : MeshElement3D
    {
        /// <summary>
        /// The diameter property.
        /// </summary>
        public static readonly DependencyProperty DiameterProperty = DependencyProperty.Register(
            "Diameter", typeof(double), typeof(PipeVisual3D), new UIPropertyMetadata(1.0, GeometryChanged));

        /// <summary>
        /// The inner diameter property.
        /// </summary>
        public static readonly DependencyProperty InnerDiameterProperty = DependencyProperty.Register(
            "InnerDiameter", typeof(double), typeof(PipeVisual3D), new UIPropertyMetadata(0.0, GeometryChanged));

        /// <summary>
        /// The point 1 property.
        /// </summary>
        public static readonly DependencyProperty Point1Property = DependencyProperty.Register(
            "Point1",
            typeof(Point3D),
            typeof(PipeVisual3D),
            new UIPropertyMetadata(new Point3D(0, 0, 0), GeometryChanged));

        /// <summary>
        /// The point 2 property.
        /// </summary>
        public static readonly DependencyProperty Point2Property = DependencyProperty.Register(
            "Point2",
            typeof(Point3D),
            typeof(PipeVisual3D),
            new UIPropertyMetadata(new Point3D(0, 0, 10), GeometryChanged));

        /// <summary>
        /// The theta div property.
        /// </summary>
        public static readonly DependencyProperty ThetaDivProperty = DependencyProperty.Register(
            "ThetaDiv", typeof(int), typeof(PipeVisual3D), new UIPropertyMetadata(36, GeometryChanged));

        /// <summary>
        /// Gets or sets the (outer) diameter.
        /// </summary>
        /// <value>The diameter.</value>
        public double Diameter
        {
            get
            {
                return (double)this.GetValue(DiameterProperty);
            }

            set
            {
                this.SetValue(DiameterProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the inner diameter.
        /// </summary>
        /// <value>The inner diameter.</value>
        public double InnerDiameter
        {
            get
            {
                return (double)this.GetValue(InnerDiameterProperty);
            }

            set
            {
                this.SetValue(InnerDiameterProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the start point.
        /// </summary>
        /// <value>The start point.</value>
        public Point3D Point1
        {
            get
            {
                return (Point3D)this.GetValue(Point1Property);
            }

            set
            {
                this.SetValue(Point1Property, value);
            }
        }

        /// <summary>
        /// Gets or sets the end point.
        /// </summary>
        /// <value>The end point.</value>
        public Point3D Point2
        {
            get
            {
                return (Point3D)this.GetValue(Point2Property);
            }

            set
            {
                this.SetValue(Point2Property, value);
            }
        }

        /// <summary>
        /// Gets or sets the theta div.
        /// </summary>
        /// <value>The theta div.</value>
        public int ThetaDiv
        {
            get
            {
                return (int)this.GetValue(ThetaDivProperty);
            }

            set
            {
                this.SetValue(ThetaDivProperty, value);
            }
        }

        /// <summary>
        /// Do the tesselation and return the <see cref="MeshGeometry3D"/>.
        /// </summary>
        /// <returns>A triangular mesh geometry.</returns>
        protected override MeshGeometry3D Tessellate()
        {
            var builder = new MeshBuilder(false,false);
            builder.AddPipe(this.Point1, this.Point2, this.InnerDiameter, this.Diameter, this.ThetaDiv);
            return builder.ToMesh();
        }

    }
}