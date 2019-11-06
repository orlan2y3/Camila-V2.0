Imports System.Data.SqlClient

Public Class frmBuscarFacturasCredito

    Sub ActualizaClientes()
        cmbCliente.Items.Clear()
        cmbIdCliente.Items.Clear()

        StrSql = "SELECT DISTINCT(F.ID_CLIENTE) AS CLIENTE, C.NOMBRE FROM FACTURA F, CLIENTES C" _
        & " WHERE F.CONDICION ='Crédito' AND F.PAGADA ='N' AND F.ID_CLIENTE = C.ID"
        Da = New OleDb.OleDbDataAdapter(StrSql, Cnn)
        Da.Fill(Ds, "clientes")
        If Ds.Tables("clientes").Rows.Count > 0 Then
            For Each nombre In Ds.Tables("clientes").Rows
                cmbIdCliente.Items.Add(nombre("cliente"))
                cmbCliente.Items.Add(nombre("nombre"))
            Next
            Ds.Clear()
        Else
            Ds.Clear()
            MsgBox("No hay facturas pendientes de pagos en estos momentos", vbInformation)
            Return

        End If
    End Sub

    Private Sub frmBuscarFacturasCredito_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ActualizaClientes()
    End Sub

End Class