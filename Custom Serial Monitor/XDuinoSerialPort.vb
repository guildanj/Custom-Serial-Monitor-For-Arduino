Imports System.IO.Ports
Imports System.Text

Public Class XDuinoSerialPort
    Public Property Description As String
    Public Property SerialLogs As String
    Public Event DataReceived(msg As String)
    Public Property WhatError As String

#Region "  Manager Enums"
    Public Enum TransmissionType
        Text
        Hex
    End Enum
#End Region

#Region "Manager Variables"
    'property variables
    Private _baudRate As String = String.Empty
    Private _parity As String = String.Empty
    Private _stopBits As String = String.Empty
    Private _dataBits As String = String.Empty
    Private _portName As String = String.Empty
    Public comPort As New SerialPort()
#End Region

#Region "Manager Properties"
    ''' <summary>
    ''' Property to hold the BaudRate
    ''' of our manager class
    ''' </summary>
    Public Property BaudRate() As String
        Get
            Return _baudRate
        End Get
        Set(value As String)
            _baudRate = value
        End Set
    End Property

    ''' <summary>
    ''' property to hold the Parity
    ''' of our manager class
    ''' </summary>
    Public Property Parity() As String
        Get
            Return _parity
        End Get
        Set(value As String)
            _parity = value
        End Set
    End Property

    ''' <summary>
    ''' property to hold the StopBits
    ''' of our manager class
    ''' </summary>
    Public Property StopBits() As String
        Get
            Return _stopBits
        End Get
        Set(value As String)
            _stopBits = value
        End Set
    End Property

    ''' <summary>
    ''' property to hold the DataBits
    ''' of our manager class
    ''' </summary>
    Public Property DataBits() As String
        Get
            Return _dataBits
        End Get
        Set(value As String)
            _dataBits = value
        End Set
    End Property

    ''' <summary>
    ''' property to hold the PortName
    ''' of our manager class
    ''' </summary>
    Public Property PortName() As String
        Get
            Return _portName
        End Get
        Set(value As String)
            _portName = value
        End Set
    End Property
#End Region

#Region "Manager Constructors"
    ''' <summary>
    ''' Constructor to set the properties of our Manager Class
    ''' </summary>
    ''' <param name="baud">Desired BaudRate</param>
    ''' <param name="par">Desired Parity</param>
    ''' <param name="sBits">Desired StopBits</param>
    ''' <param name="dBits">Desired DataBits</param>
    ''' <param name="name">Desired PortName</param>
    Public Sub New(baud As String, par As String, sBits As String, dBits As String, name As String, ByVal descrip As String)
        _baudRate = baud
        _parity = par
        _stopBits = sBits
        _dataBits = dBits
        _portName = name
        Description = descrip
        'now add an event handler
        AddHandler comPort.DataReceived, New SerialDataReceivedEventHandler(AddressOf comPort_DataReceived)
    End Sub
#End Region

#Region "WriteData"
    Public Sub WriteData(msg As String)
        'first make sure the port is open
        'if its not open then open it
        If Not (comPort.IsOpen = True) Then
            comPort.Open()
        End If
        'send the message to the port
        Try
            comPort.Write(msg)
        Catch ex As Exception

        End Try
        'display the message
    End Sub
#End Region

#Region "HexToByte"
    ''' <summary>
    ''' method to convert hex string into a byte array
    ''' </summary>
    ''' <param name="msg">string to convert</param>
    ''' <returns>a byte array</returns>
    Private Function HexToByte(msg As String) As Byte()
        'remove any spaces from the string
        msg = msg.Replace(" ", "")
        'create a byte array the length of the
        'divided by 2 (Hex is 2 characters in length)
        Dim comBuffer As Byte() = New Byte(msg.Length / 2 - 1) {}
        'loop through the length of the provided string
        For i As Integer = 0 To msg.Length - 1 Step 2
            'convert each set of 2 characters to a byte
            'and add to the array
            comBuffer(i / 2) = CByte(Convert.ToByte(msg.Substring(i, 2), 16))
        Next
        'return the array
        Return comBuffer
    End Function
#End Region

#Region "ByteToHex"
    ''' <summary>
    ''' method to convert a byte array into a hex string
    ''' </summary>
    ''' <param name="comByte">byte array to convert</param>
    ''' <returns>a hex string</returns>
    Private Function ByteToHex(comByte As Byte()) As String
        'create a new StringBuilder object
        Dim builder As New StringBuilder(comByte.Length * 3)
        'loop through each byte in the array
        For Each data As Byte In comByte
            'convert the byte to a string and add to the stringbuilder
            builder.Append(Convert.ToString(data, 16).PadLeft(2, "0"c).PadRight(3, " "c))
        Next
        'return the converted value
        Return builder.ToString().ToUpper()
    End Function
#End Region

#Region "OpenPort"
    Public Function OpenPort() As Boolean
        Try
            'first check if the port is already open
            'if its open then close it
            If comPort.IsOpen = True Then
                comPort.Close()
            End If

            'set the properties of our SerialPort Object
            comPort.BaudRate = Integer.Parse(_baudRate)
            'BaudRate
            comPort.DataBits = Integer.Parse(_dataBits)
            'DataBits
            comPort.StopBits = DirectCast([Enum].Parse(GetType(StopBits), _stopBits), StopBits)
            'StopBits
            comPort.Parity = DirectCast([Enum].Parse(GetType(Parity), _parity), Parity)
            'Parity
            comPort.PortName = _portName
            'PortName
            'now open the port
            comPort.Open()
            'display message
            Return True
        Catch ex As Exception
            WhatError = ex.Message
            Return False
        End Try
    End Function
#End Region

#Region "ClosePort"

    Public Function ClosePort() As Boolean
        Try
            'first check if the port is already open
            'if its open then close it
            If comPort.IsOpen = True Then
                comPort.Close()
            End If

            'return true if port is closed
            If comPort.IsOpen = False Then
                Return True
            End If

            Return False
        Catch ex As Exception
            Console.WriteLine("we" & ex.Message)
            Return False
        End Try
    End Function

#End Region

#Region "SetParityValues"
    Public Sub SetParityValues(obj As Object)
        For Each str As String In [Enum].GetNames(GetType(Parity))
            DirectCast(obj, ComboBox).Items.Add(str)
        Next
    End Sub
#End Region

#Region "SetStopBitValues"
    Public Sub SetStopBitValues(obj As Object)
        For Each str As String In [Enum].GetNames(GetType(StopBits))
            DirectCast(obj, ComboBox).Items.Add(str)
        Next
    End Sub
#End Region

#Region "SetPortNameValues"
    Public Sub SetPortNameValues(obj As Object)

        For Each str As String In SerialPort.GetPortNames()
            DirectCast(obj, ComboBox).Items.Add(str)
        Next
    End Sub
#End Region

#Region "comPort_DataReceived"
    ''' <summary>
    ''' method that will be called when theres data waiting in the buffer
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub comPort_DataReceived(sender As Object, e As SerialDataReceivedEventArgs)
        Try
            Dim msg As String = comPort.ReadLine
            SerialLogs = SerialLogs & vbCrLf & msg
            RaiseEvent DataReceived(msg)

        Catch ex As Exception

        End Try
    End Sub
#End Region

End Class