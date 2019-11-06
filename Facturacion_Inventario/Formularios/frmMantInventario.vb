Imports System.Data.OleDb

Public Class frmMantInventario
    Private Sub frmMantInventario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtRef.BackColor = Color.Beige
        txtDescrip.BackColor = Color.White
        txtCosto.BackColor = Color.White
        txtPrecio.BackColor = Color.White
        txtExistencia.BackColor = Color.White
        txtExistenciaMin.BackColor = Color.White

        txtBref.Select()
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        txtBref.Clear() : txtRef.Clear() : txtDescrip.Clear() : txtCosto.Clear() : txtPrecio.Clear() : txtExistencia.Clear() : txtExistenciaMin.Clear()
        txtBref.Focus()
        Me.Hide()
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click

        Dim Fecha As String = ""
        Dim Fecha2 As String = ""
        Dim CostoTotal As Double = 0
        Dim CostoPromedio As Double = 0
        Dim Cantidad As Integer = 0

        Try

            StrSql = "SELECT * FROM INVENTARIO WHERE REFERENCIA ='" & Trim(txtBref.Text) & "'"
            objCmd = New OleDbCommand(StrSql, Cnn)
            objReader = objCmd.ExecuteReader
            If objReader.HasRows Then
                objReader.Read()
                txtRef.Text = objReader("referencia").ToString
                txtDescrip.Text = objReader("descripcion").ToString
                txtCosto.Text = objReader("costo")
                txtCP.Text = objReader("costo")
                txtPrecio.Text = objReader("precio_venta")
                txtExistencia.Text = objReader("existencia")
                txtExistenciaMin.Text = objReader("existencia_minima")
                objReader.Close()

                btnDelete.Enabled = True
                txtRef.BackColor = Color.Beige
                txtDescrip.BackColor = Color.NavajoWhite
                txtCosto.BackColor = Color.NavajoWhite
                txtPrecio.BackColor = Color.NavajoWhite
                txtExistencia.BackColor = Color.NavajoWhite
                txtExistenciaMin.BackColor = Color.NavajoWhite
                'txtExistencia.Focus()


                Fecha = Format(Today, "yyyy/MM/dd")
                Fecha2 = Format(Today.AddMonths(-1), "yyyy/MM/dd")

                Cantidad = 0 : CostoTotal = 0 : CostoPromedio = 0

                StrSql = "SELECT COSTO FROM ENTRADAS_PRODUCTOS WHERE REFERENCIA ='" & Trim(txtBref.Text) _
                & "' AND FECHA >='" & Fecha2 & "' AND FECHA <='" & Fecha & "'"
                objCmd = New OleDb.OleDbCommand(StrSql, Cnn)
                objReader = objCmd.ExecuteReader
                If objReader.HasRows Then
                    While objReader.Read
                        Cantidad = Cantidad + 1
                        CostoTotal = CostoTotal + objReader("costo")
                    End While
                    objReader.Close()

                    CostoPromedio = CostoTotal / Cantidad
                    txtCP.Text = FormatNumber(CostoPromedio, 2)
                Else
                    objReader.Close()
                End If
                txtBref.Clear()
            Else
                objReader.Close()
                MsgBox("No se encontró esa referencia en el inventario", vbInformation)
                Return
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return
        End Try

    End Sub

    Private Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click
        Try
            If Len(Trim(txtRef.Text)) = 0 Then
                MsgBox("Primero debe buscar el producto", vbInformation)
                txtBref.Focus()
                Return
            End If

            If Len(Trim(txtDescrip.Text)) = 0 Then
                MsgBox("Debe digitar la descripción del producto", vbInformation)
                txtDescrip.Focus()
                Return
            End If

            If Not IsNumeric(txtCosto.Text) Then
                MsgBox("El costo debe ser numérico", vbInformation)
                txtCosto.Focus()
                Return
            End If

            If Not IsNumeric(txtPrecio.Text) Then
                MsgBox("El precio de venta debe ser numérico", vbInformation)
                txtPrecio.Focus()
                Return
            End If

            If Not IsNumeric(txtExistencia.Text) Then
                MsgBox("La Existencia debe ser numérica", vbInformation)
                txtExistencia.Focus()
                Return
            ElseIf CDbl(txtExistencia.Text) < 0 Then
                MsgBox("El valor de la Existencia no puede ser menor que cero", vbInformation)
                txtExistencia.Focus()
                Return
            End If

            If Not IsNumeric(txtExistenciaMin.Text) Then
                txtExistenciaMin.Text = 0
                Return
            ElseIf CDbl(txtExistenciaMin.Text) < 0 Then
                MsgBox("El valor de la Existencia minima no puede ser menor que cero", vbInformation)
                txtExistenciaMin.Focus()
                Return
            End If

            StrSql = "UPDATE INVENTARIO SET DESCRIPCION ='" & Trim(txtDescrip.Text) & "', COSTO =" & CDec(txtCosto.Text) _
            & ", PRECIO_VENTA =" & CDec(txtPrecio.Text) & ", EXISTENCIA = " & CDbl(txtExistencia.Text) _
            & ", EXISTENCIA_MINIMA =" & CDbl(txtExistenciaMin.Text) & " WHERE REFERENCIA ='" & Trim(txtRef.Text) & "'"
            objCmd = New OleDbCommand(StrSql, Cnn)
            RA = objCmd.ExecuteNonQuery()
            If RA > 0 Then
                btnDelete.Enabled = False
                MsgBox("Ok. Inventario actualizado", vbInformation)
                txtRef.Clear() : txtDescrip.Clear() : txtCosto.Clear() : txtPrecio.Clear() : txtExistencia.Clear() : txtExistenciaMin.Clear()
                txtRef.BackColor = Color.Beige
                txtDescrip.BackColor = Color.White
                txtCosto.BackColor = Color.White
                txtPrecio.BackColor = Color.White
                txtExistencia.BackColor = Color.White
                txtExistenciaMin.BackColor = Color.White

                txtBref.Select()
            Else
                MsgBox("Error actualizando el inventario", MsgBoxStyle.Critical)
                Return
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return
        End Try

    End Sub

    Private Sub txtRef_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtRef.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtDescrip_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDescrip.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If

    End Sub

    Private Sub txtCosto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCosto.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtPrecio_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPrecio.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtExistencia_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtExistencia.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtCosto_Leave(sender As Object, e As EventArgs) Handles txtCosto.Leave
        If IsNumeric(txtCosto.Text) Then
            txtCosto.Text = FormatNumber(txtCosto.Text, 2)
        End If

    End Sub

    Private Sub txtPrecio_Leave(sender As Object, e As EventArgs) Handles txtPrecio.Leave
        If IsNumeric(txtPrecio.Text) Then
            txtPrecio.Text = FormatNumber(txtPrecio.Text, 2)
        End If

    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            If Len(Trim(txtRef.Text)) = 0 Then
                MsgBox("Primero debe buscar el producto", vbInformation)
                txtBref.Focus()
                Return
            End If

            StrSql = "SELECT TOP 1 ID_DETALLES_FACTURA FROM DETALLES_FACTURA WHERE REFERENCIA ='" & Trim(txtRef.Text) & "'"
            objCmd = New OleDb.OleDbCommand(StrSql, Cnn)
            objReader = objCmd.ExecuteReader
            If objReader.HasRows Then
                objReader.Close()
                MsgBox("Hay Facturas hechas con ese producto. NO puede ser eliminado", vbCritical)
                Return
            Else
                objReader.Close()
            End If

            StrSql = "SELECT TOP 1 ID_DETALLES_COTIZACION FROM DETALLES_COTIZACION WHERE REFERENCIA ='" & Trim(txtRef.Text) & "'"
            objCmd = New OleDb.OleDbCommand(StrSql, Cnn)
            objReader = objCmd.ExecuteReader
            If objReader.HasRows Then
                objReader.Close()
                MsgBox("Hay Cotizaciones hechas con ese producto. NO puede ser eliminado", vbCritical)
                Return
            Else
                objReader.Close()
            End If

            If MsgBox("Seguro que desea eliminar ese Producto ?", vbQuestion + vbYesNo + vbDefaultButton2) = vbNo Then
                Return
            End If

            StrSql = "DELETE * FROM INVENTARIO WHERE REFERENCIA ='" & Trim(txtRef.Text) & "'"
            objCmd = New OleDbCommand(StrSql, Cnn)
            RA = objCmd.ExecuteNonQuery()
            If RA > 0 Then
                btnDelete.Enabled = False
                MsgBox("Ok. Producto eliminado del inventario", vbInformation)
                txtRef.Clear() : txtDescrip.Clear() : txtCosto.Clear() : txtPrecio.Clear() : txtExistencia.Clear() : txtExistenciaMin.Clear()
                txtRef.BackColor = Color.Beige
                txtDescrip.BackColor = Color.White
                txtCosto.BackColor = Color.White
                txtPrecio.BackColor = Color.White
                txtExistencia.BackColor = Color.White
                txtExistenciaMin.BackColor = Color.White

                txtBref.Select()
            Else
                MsgBox("Error. No fue posible eliminar el producto del inventario", MsgBoxStyle.Critical)
                Return
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Return
        End Try
    End Sub

    Private Sub txtBref_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBref.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            btnBuscar.Focus()
        End If
    End Sub

    Private Sub txtBref_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBref.KeyDown
        If e.KeyValue = Keys.F2 Then
            FBuscarProductos.Tag = "frmMantInventario"
            FBuscarProductos.Show()
            FBuscarProductos.FormatGrid()
            FBuscarProductos.txtReferencia.Focus()
        End If
    End Sub

    Private Sub txtDescrip_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDescrip.KeyDown
        If e.KeyValue = Keys.F2 Then
            FBuscarProductos.Tag = "frmMantInventario"
            FBuscarProductos.Show()
            FBuscarProductos.txtReferencia.Focus()
        End If
    End Sub

    Private Sub txtExistenciaMin_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtExistenciaMin.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            btnGrabar.Focus()
        End If
    End Sub
End Class