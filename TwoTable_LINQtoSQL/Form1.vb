Option Explicit On
Option Strict On
Public Class Form1
    Dim db As New dbNorthwindDataContext
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ps = From p In db.Products
                 From c In db.Categories
                 Where (p.CategoryID = c.CategoryID)
                 Select New With {
                    .ProductID = p.ProductID,
                     .ProductName = p.ProductName,
                     .CategoryName = c.CategoryName
        }
        If ps.Count() > 0 Then
            dgvProducts.DataSource = ps.ToList
        End If
    End Sub
End Class
