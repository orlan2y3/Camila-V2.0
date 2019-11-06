Imports System.Data.OleDb

Public Class Buscar_Cotizacion_facturacion

    Private ds As DataSet = New DataSet
    Private ds1 As DataSet = New DataSet
    Dim EstadoCotizacion As String

    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        Try

            Dim myQuery As String = ""

            ds.Clear()

            If IsNumeric(txtBuscar.Text) Then
                myQuery = "SELECT TOP 50 co.id_cotizacion, cli.nombre as Cliente, co.fecha, co.total, co.estado FROM cotizacion co, clientes cli" _
                & " where ID_COTIZACION =" & CLng(txtBuscar.Text) & " AND CO.ID_CLIENTE = CLI.ID ORDER BY co.id_cotizacion DESC"
                Dim da As OleDbDataAdapter = New OleDbDataAdapter(myQuery, Cnn)
                da.Fill(ds, "cotizacion")

                dgvbuscar_cotizacion.DataSource = ds
                dgvbuscar_cotizacion.DataMember = "cotizacion"

                dgvbuscar_cotizacion.Columns(4).DefaultCellStyle.Format = "##,###.00"
                txtBuscar.Clear()
                Return
            End If

            If CheckBox1.Checked = False Then

                If Trim(txtBuscar.Text) = "" Then
                    myQuery = "SELECT TOP 50 co.id_cotizacion, cli.nombre as Cliente, co.fecha, co.total, co.estado FROM cotizacion co, clientes cli" _
                    & " where co.estado = 'Normal' AND CO.ID_CLIENTE = CLI.ID ORDER BY co.id_cotizacion DESC"
                    Dim da As OleDbDataAdapter = New OleDbDataAdapter(myQuery, Cnn)
                    da.Fill(ds, "cotizacion")

                    dgvbuscar_cotizacion.DataSource = ds
                    dgvbuscar_cotizacion.DataMember = "cotizacion"

                    dgvbuscar_cotizacion.Columns(4).DefaultCellStyle.Format = "##,###.00"

                Else
                    myQuery = "SELECT TOP 50 co.id_cotizacion, cli.nombre as Cliente, co.fecha, co.total, co.estado FROM cotizacion co, clientes cli" _
                        & "  where co.estado = 'Normal' and cli.nombre like '" & txtBuscar.Text & "%' AND CO.ID_CLIENTE = CLI.ID ORDER BY co.id_cotizacion DESC"
                    Dim da As OleDbDataAdapter = New OleDbDataAdapter(myQuery, Cnn)
                    da.Fill(ds, "cotizacion")

                    dgvbuscar_cotizacion.DataSource = ds
                    dgvbuscar_cotizacion.DataMember = "cotizacion"

                    dgvbuscar_cotizacion.Columns(4).DefaultCellStyle.Format = "##,###.00"
                End If

            Else

                If Trim(txtBuscar.Text) = "" Then
                    myQuery = "SELECT TOP 50 co.id_cotizacion, cli.nombre as Cliente, co.fecha, co.total, co.estado FROM cotizacion co, clientes cli" _
                         & " where co.estado = 'Anulada' AND CO.ID_CLIENTE = CLI.ID ORDER BY co.id_cotizacion DESC"
                    Dim da As OleDbDataAdapter = New OleDbDataAdapter(myQuery, Cnn)
                    da.Fill(ds, "cotizacion")

                    dgvbuscar_cotizacion.DataSource = ds
                    dgvbuscar_cotizacion.DataMember = "cotizacion"

                    dgvbuscar_cotizacion.Columns(4).DefaultCellStyle.Format = "##,###.00"

                Else
                    myQuery = "SELECT TOP 50 co.id_cotizacion, cli.nombre as Cliente, co.fecha, co.total, co.estado FROM cotizacion co, clientes cli" _
                        & "  where co.estado = 'Anulada' and cli.nombre like '" & txtBuscar.Text & "%' AND CO.ID_CLIENTE = CLI.ID ORDER BY co.id_cotizacion DESC"
                    Dim da As OleDbDataAdapter = New OleDbDataAdapter(myQuery, Cnn)
                    da.Fill(ds, "cotizacion")

                    dgvbuscar_cotizacion.DataSource = ds
                    dgvbuscar_cotizacion.DataMember = "cotizacion"

                    dgvbuscar_cotizacion.Columns(4).DefaultCellStyle.Format = "##,###.00"
                End If

            End If

            txtBuscar.Clear()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub Buscar_Cotizacion_facturacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgvbuscar_cotizacion.ColumnHeadersDefaultCellStyle.BackColor = Color.Coral
        Dim Fecha = Format(Now.AddMonths(-30), "dd/MM/yyyy")
        txtInicial.Text = Fecha
        txtFinal.Text = Format(Date.Today, "dd/MM/yyyy")
        txtBuscar.Focus()
    End Sub

    Private Sub btsalir_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub Buscar_Cotizacion_facturacion_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        ds.Clear()
    End Sub

    Private Sub dgvbuscar_cotizacion_DoubleClick(sender As Object, e As EventArgs) Handles dgvbuscar_cotizacion.DoubleClick
        Try

            If IsNothing(dgvbuscar_cotizacion.CurrentRow.Cells(0).Value) Then
                Return
            End If

            NC = dgvbuscar_cotizacion.CurrentRow.Cells(0).Value

            Dim dr As OleDbDataReader
            Dim query As String = "SELECT co.id_cotizacion, co.id_cliente, cli.rnc, cli.nombre, co.estado, co.porciento_itbis, co.cantidad_descuento" _
            & " FROM cotizacion co, clientes cli where co.id_cotizacion = " & NC

            Dim cmb As OleDbCommand = New OleDbCommand(query, Cnn)
            dr = cmb.ExecuteReader()
            dr.Read()

            Ffactura.txtIdCliente.Text = dr("id_cliente")
            Ffactura.txtrnccliente.Text = dr("rnc").ToString
            Ffactura.txtcliente.Text = dr("nombre").ToString
            If dr("porciento_itbis") = 0 Then
                Ffactura.cb1.Checked = True
                Ffactura.cb1.Font = New Font(Ffactura.cb1.Font, FontStyle.Bold)
            End If
            Ffactura.txtdescuento.Text = FormatNumber(dr("cantidad_descuento"), 2)
            'If dr("cantidad_descuento") = 0 Then
            '    Ffactura.txtdescuento.Text = 0
            'End If

            EstadoCotizacion = dr("estado").ToString

            dr.Close()

            If EstadoCotizacion = "Anulada" Then
                MsgBox("Las cotizaciones anuladas no se pueden traer para facturar", MsgBoxStyle.Information)
                Return
            End If

            Ffactura.FormatGrid()

            '***** Agrego los productos que traigo de la cotizacion a la factura uno por uno *****

            Dim query1 As String = "SELECT id_cotizacion, referencia, descripcion, cantidad, precio, id_condicion FROM detalles_cotizacion WHERE id_cotizacion = " & NC
            Dim cmb1 As OleDbCommand = New OleDbCommand(query1, Cnn)
            dr = cmb1.ExecuteReader
            If dr.HasRows Then
                While dr.Read()
                    Ffactura.txtRef.Text = dr("referencia").ToString

                    Dim Argumento As New KeyPressEventArgs(Convert.ToChar(13))
                    Call Ffactura.txtRef_KeyPress(sender, Argumento)

                    'Ffactura.txtproducto.Text = dr("descripcion").ToString
                    'Ffactura.txtprecio.Text = dr("precio")
                    If dr("id_condicion") > 0 Then
                        Ffactura.cmbIdCondicion.Text = dr("id_condicion")
                    Else
                        If Ffactura.cmbProducto.Text = "SELECCIONA UNA OPCION ..." Then
                            Ffactura.cmbIdCondicion.SelectedIndex = 1
                        End If
                    End If
                    Ffactura.txtcantidad.Text = dr("cantidad")
                    Ffactura.btagregar.PerformClick()

                End While
                dr.Close()
            Else
                dr.Close()
                Return
            End If

            Me.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Try

            If FechaValida(txtInicial.Text) = False Then
                MsgBox("La fecha inicial no es una fecha valida, verifique", vbInformation)
                txtInicial.Focus()
                Return
            End If

            If FechaValida(txtFinal.Text) = False Then
                MsgBox("La fecha final no es una fecha valida, verifique", vbInformation)
                txtFinal.Focus()
                Return
            End If

            Dim myQuery As String = ""

            ds.Clear()

            If CheckBox1.Checked = False Then

                If Trim(txtBuscar.Text) = "" Then
                    myQuery = "SELECT TOP 50 co.id_cotizacion, cli.nombre as Cliente, co.fecha, co.total, co.estado FROM cotizacion co, clientes cli" _
                    & " where co.estado = 'Normal'" & " And co.fecha >='" & Efecha(txtInicial.Text) & "' AND co.fecha <='" & Efecha(txtFinal.Text) _
                    & "' And CO.ID_CLIENTE = CLI.ID ORDER BY co.id_cotizacion DESC"
                    Dim da As OleDbDataAdapter = New OleDbDataAdapter(myQuery, Cnn)
                    da.Fill(ds, "cotizacion")

                    dgvbuscar_cotizacion.DataSource = ds
                    dgvbuscar_cotizacion.DataMember = "cotizacion"

                    dgvbuscar_cotizacion.Columns(4).DefaultCellStyle.Format = "##,###.00"

                Else
                    myQuery = "Select TOP 50 co.id_cotizacion, cli.nombre As Cliente, co.fecha, co.total, co.estado FROM cotizacion co, clientes cli" _
                    & "  where co.estado = 'Normal' and cli.cliente like '" & txtBuscar.Text & "%'" _
                    & " And co.fecha >='" & Efecha(txtInicial.Text) & "' AND co.fecha <='" & Efecha(txtFinal.Text) _
                    & "' AND CO.ID_CLIENTE = CLI.ID ORDER BY co.id_cotizacion DESC"
                    Dim da As OleDbDataAdapter = New OleDbDataAdapter(myQuery, Cnn)
                    da.Fill(ds, "cotizacion")

                    dgvbuscar_cotizacion.DataSource = ds
                    dgvbuscar_cotizacion.DataMember = "cotizacion"

                    dgvbuscar_cotizacion.Columns(4).DefaultCellStyle.Format = "##,###.00"
                End If

            Else

                If Trim(txtBuscar.Text) = "" Then
                    myQuery = "SELECT TOP 50 co.id_cotizacion, cli.nombre as Cliente, co.fecha, co.total, co.estado FROM cotizacion co, clientes cli" _
                    & " where co.estado = 'Anulada'" & " And co.fecha >='" & Efecha(txtInicial.Text) & "' AND co.fecha <='" & Efecha(txtFinal.Text) _
                    & "' And CO.ID_CLIENTE = CLI.ID ORDER BY co.id_cotizacion DESC"
                    Dim da As OleDbDataAdapter = New OleDbDataAdapter(myQuery, Cnn)
                    da.Fill(ds, "cotizacion")

                    dgvbuscar_cotizacion.DataSource = ds
                    dgvbuscar_cotizacion.DataMember = "cotizacion"

                    dgvbuscar_cotizacion.Columns(4).DefaultCellStyle.Format = "##,###.00"

                Else
                    myQuery = "Select TOP 50 co.id_cotizacion, cli.nombre As Cliente, co.fecha, co.total, co.estado FROM cotizacion co, clientes cli" _
                    & "  where co.estado = 'Anulada' and cli.cliente like '" & txtBuscar.Text & "%'" _
                    & " And co.fecha >='" & Efecha(txtInicial.Text) & "' AND co.fecha <='" & Efecha(txtFinal.Text) _
                    & "' AND CO.ID_CLIENTE = CLI.ID ORDER BY co.id_cotizacion DESC"
                    Dim da As OleDbDataAdapter = New OleDbDataAdapter(myQuery, Cnn)
                    da.Fill(ds, "cotizacion")

                    dgvbuscar_cotizacion.DataSource = ds
                    dgvbuscar_cotizacion.DataMember = "cotizacion"

                    dgvbuscar_cotizacion.Columns(4).DefaultCellStyle.Format = "##,###.00"
                End If

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

End Class