Imports System.Drawing.Drawing2D

Public Class RoundedGroupbox
    Inherits GroupBox

    Private _radius As Integer = 15
    Public Property CornerRadius() As Integer
        Get
            Return _radius
        End Get
        Set(ByVal value As Integer)
            _radius = value
            Me.Invalidate()
        End Set
    End Property

    Public Sub New()
        Me.SetStyle(ControlStyles.ResizeRedraw, True)
        Me.DoubleBuffered = True
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)

        Dim rect As New Rectangle(0, 0, Me.Width - 1, Me.Height - 1)
        Using path As New GraphicsPath()
            path.AddArc(rect.X, rect.Y, _radius, _radius, 180, 90)
            path.AddArc(rect.Width - _radius, rect.Y, _radius, _radius, 270, 90)
            path.AddArc(rect.Width - _radius, rect.Height - _radius, _radius, _radius, 0, 90)
            path.AddArc(rect.X, rect.Height - _radius, _radius, _radius, 90, 90)
            path.CloseFigure()

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
            Using bgBrush As New SolidBrush(Me.BackColor)
                e.Graphics.FillPath(bgBrush, path)
            End Using

            Using borderPen As New Pen(Color.Gray, 1)
                e.Graphics.DrawPath(borderPen, path)
            End Using

            ' Gambar teks GroupBox
            If Not String.IsNullOrEmpty(Me.Text) Then
                Dim textSize As SizeF = e.Graphics.MeasureString(Me.Text, Me.Font)
                Dim textRect As New Rectangle(10, 0, CInt(textSize.Width), CInt(textSize.Height))
                e.Graphics.FillRectangle(New SolidBrush(Me.BackColor), textRect)
                TextRenderer.DrawText(e.Graphics, Me.Text, Me.Font, textRect, Me.ForeColor, TextFormatFlags.Left)
            End If
        End Using
    End Sub
End Class