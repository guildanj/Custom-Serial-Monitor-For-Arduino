Imports System.IO
Imports System.IO.Ports
Imports System.Management
Imports System.ComponentModel
Public Class Form1

    Dim WithEvents SelectedPort As XDuinoSerialPort
    Dim SerialPortList As New List(Of String())
    Dim ProgramEdit As Boolean = True

    Private Sub Form1_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If SelectedPort IsNot Nothing Then
            SelectedPort.ClosePort()
        End If
    End Sub

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        cmbBaud.SelectedIndex = 4
        cmbLine.SelectedIndex = 1
        ProgramEdit = False
        ControlsState(False)
        RefreshSerialPorts()
    End Sub

    Private Sub RefreshSerialPorts()
        cmbPort.Items.Clear()
        SerialPortList.Clear()
        Using searcher = New ManagementObjectSearcher("SELECT * FROM Win32_PnPEntity WHERE Caption like '%(COM%'")
            Dim portnames = SerialPort.GetPortNames()
            Dim ports = searcher.[Get]().Cast(Of ManagementBaseObject)().ToList().[Select](Function(p) p("Caption").ToString())
            Dim portList = portnames.[Select](Function(n) n + " " + ports.FirstOrDefault(Function(s) s.Contains(n))).ToList()


            For Each s As String In portList
                'Create new toolstripmenu item
                Dim descrip As String = s.Remove(0, s.IndexOf(" ") + 1)
                If descrip = "" Then descrip = s.Substring(0, s.IndexOf(" "))

                Dim portname As String = s.Remove(s.IndexOf(" "), s.Length - (s.IndexOf(" ")))
                Dim arr() As String = {portname, descrip}

                cmbPort.Items.Add(s)
                SerialPortList.Add(arr)
            Next
        End Using
    End Sub

    Private Sub ControlsState(ByVal bool As Boolean)
        If bool Then
            btSend.Enabled = True
            btClear.Enabled = True
            txInput.Enabled = True
            cmbBaud.Enabled = True

        Else
            btSend.Enabled = False
            btClear.Enabled = False
            txInput.Enabled = False
            cmbBaud.Enabled = False
        End If
    End Sub

    Private Sub cmbPort_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbPort.SelectedIndexChanged
        If ProgramEdit Then
            Return
        End If

        If cmbPort.SelectedIndex >= 0 Then
            If SelectedPort IsNot Nothing Then
                SelectedPort.ClosePort()
                txData.Clear()
                ControlsState(False)
            End If

            SelectedPort = New XDuinoSerialPort(cmbBaud.Text.Replace(" baud", ""), "0", "1", "8", SerialPortList.Item(cmbPort.SelectedIndex)(0), SerialPortList.Item(cmbPort.SelectedIndex)(1))
            Cursor = Cursors.WaitCursor
            If SelectedPort.OpenPort() Then
                Cursor = Cursors.Default
                ControlsState(True)
            Else
                MsgBox(SelectedPort.WhatError, MsgBoxStyle.Critical, "Unable to open selected port")
                Cursor = Cursors.Default
                Return
            End If

        End If
    End Sub

    Private Sub cmbBaud_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbBaud.SelectedIndexChanged
        If ProgramEdit Then
            Return
        End If

        If SelectedPort IsNot Nothing Then
            SelectedPort.ClosePort()
            txData.Clear()
            ControlsState(False)
        End If

        SelectedPort = New XDuinoSerialPort(cmbBaud.Text.Replace(" baud", ""), "0", "1", "8", SerialPortList.Item(cmbPort.SelectedIndex)(0), SerialPortList.Item(cmbPort.SelectedIndex)(1))
        Cursor = Cursors.WaitCursor
        If SelectedPort.OpenPort() Then
            Cursor = Cursors.Default
            ControlsState(True)
        Else
            MsgBox(SelectedPort.WhatError, MsgBoxStyle.Critical, "Unable to open selected port")
            Cursor = Cursors.Default
            Return
        End If
    End Sub

    Private Sub btRefresh_Click(sender As System.Object, e As System.EventArgs) Handles btRefresh.Click
        If SelectedPort IsNot Nothing Then
            SelectedPort.ClosePort()
        End If
        RefreshSerialPorts()
        txData.Clear()
        ControlsState(False)
        txData.Clear()
    End Sub

    Private Sub btSend_Click(sender As System.Object, e As System.EventArgs) Handles btSend.Click
        If SelectedPort IsNot Nothing And txInput.Text <> "" Then
            Dim Data As String = txInput.Text
            If cmbLine.SelectedIndex = 1 Then
                Data = Data & vbLf
            ElseIf cmbLine.SelectedIndex = 2 Then
                Data = Data & vbCr
            ElseIf cmbLine.SelectedIndex = 3 Then
                Data = Data & vbCrLf
            End If
            SelectedPort.WriteData(Data)
            txInput.Text = ""
            txInput.Focus()
        End If
    End Sub

    Private Sub SelectedPort_DataReceived(msg As String) Handles SelectedPort.DataReceived
        Me.BeginInvoke(Sub()
                           Dim data As String = ""
                           If chTime.Checked Then
                               data = String.Format("[ {0} ]  ", TimeOfDay.ToString("hh:mm:ss") & TimeOfDay.Millisecond)
                           End If

                           txData.AppendText(data & msg)

                           If chScroll.Checked Then
                               txData.ScrollToCaret()
                           End If
                       End Sub)
    End Sub

    Private Sub btClear_Click(sender As System.Object, e As System.EventArgs) Handles btClear.Click
        txData.Clear()
    End Sub

    Private Sub txInput_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txInput.KeyDown
        If e.KeyCode = Keys.Enter Then
            btSend_Click(sender, e)
            e.SuppressKeyPress = True
        End If
    End Sub
End Class
