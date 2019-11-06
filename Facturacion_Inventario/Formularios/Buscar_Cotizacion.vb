Imports System.Data.OleDb

Public Class Buscar_Cotizacion

    Public ds As DataSet = New DataSet
    Public ds1 As DataSet = New DataSet

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

    Private Sub Buscar_Cotizacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgvbuscar_cotizacion.ColumnHeadersDefaultCellStyle.BackColor = Color.Coral
        Dim Fecha = Format(Now.AddMonths(-1), "dd/MM/yyyy")
        txtInicial.Text = Fecha
        txtFinal.Text = Format(Date.Today, "dd/MM/yyyy")
        txtBuscar.Select()
    End Sub

    Private Sub Buscar_Cotizacion_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        ds.Clear()
    End Sub

    Private Sub dgvbuscar_cotizacion_DoubleClick(sender As Object, e As EventArgs) Handles dgvbuscar_cotizacion.DoubleClick
        Try

            If IsNothing(dgvbuscar_cotizacion.CurrentRow.Cells(0).Value) Then
                Return
            End If

            If Not dgvbuscar_cotizacion.CurrentRow.IsNewRow Then
                NC = dgvbuscar_cotizacion.CurrentRow.Cells(0).Value
                FmantCotizacion.txtnumcotizacion.Text = NC
                FmantCotizacion.Show()
                FmantCotizacion.btnBuscar.PerformClick()
                Me.Close()
            End If

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