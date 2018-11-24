Imports System.Runtime.InteropServices
Public Class Form1
    '<deklarationen>
    Private Declare Sub keybd_event Lib "user32" (ByVal bVk As Byte, ByVal bScan As Byte, ByVal dwFlags As Long, ByVal dwExtraInfo As Long)
    Private Const KEYEVENTF_KEYUP = &H2
    Const VK_NUMLOCK = &H90
    Private Const VK_SCROLL As Short = &H91
    Private Const KEYEVENTF_EXTENDEDKEY As Short = &H1
    Private Const KEYEVENTF_KEYUP3 As Short = &H2
    Const KEYEVENTF_EXTENDEDKEY3 = &H1
    Declare Function GetKeyState Lib "user32" Alias "GetKeyState" (ByVal ByValnVirtKey As Integer) As Short
    <DllImport("user32.dll")>
    Private Shared Sub keybd_event(ByVal bVk As Byte, ByVal bScan As Byte, ByVal dwFlags As UInteger, ByVal dwExtraInfo As Integer)
    End Sub
    Const VK_CAPITAL = &H14
    Const KEYEVENTF_KEYUP2 = &H2
    '</deklarationen>


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        keybd_event(VK_CAPITAL, 0, 0, 0)
        keybd_event(VK_CAPITAL, 0, KEYEVENTF_KEYUP2, 0)

        'capital = capslock (auf der Tastatur)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        keybd_event(VK_NUMLOCK, 0, 0, 0)
        keybd_event(VK_NUMLOCK, 0, KEYEVENTF_KEYUP2, 0)

        'numlock = Num (auf der Tastatur)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        keybd_event(VK_SCROLL, &H45, KEYEVENTF_EXTENDEDKEY3 Or 0, 0)
        keybd_event(VK_SCROLL, &H45, KEYEVENTF_EXTENDEDKEY3 Or KEYEVENTF_KEYUP3, 0)

        'scroll = Rollen (auf der Tastatur)
    End Sub



    '<Effekt Welle>
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        keybd_event(VK_NUMLOCK, 0, 0, 0)
        keybd_event(VK_NUMLOCK, 0, KEYEVENTF_KEYUP2, 0)
        Timer1.Enabled = False
        Timer2.Start()
        Timer1.Stop()
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        keybd_event(VK_CAPITAL, 0, 0, 0)
        keybd_event(VK_CAPITAL, 0, KEYEVENTF_KEYUP2, 0)
        Timer3.Start()
        Timer2.Stop()
    End Sub

    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick
        keybd_event(VK_SCROLL, &H45, KEYEVENTF_EXTENDEDKEY3 Or 0, 0)
        keybd_event(VK_SCROLL, &H45, KEYEVENTF_EXTENDEDKEY3 Or KEYEVENTF_KEYUP3, 0)
        Timer1.Start()
        Timer3.Stop()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Timer1.Start()
    End Sub
    '</Effekt Welle>


    '<alle effekte aus>
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        'timer der effekte stoppen
        Timer1.Stop()
        Timer2.Stop()
        Timer3.Stop()
        Timer4.Stop()

        'if abfrage: ist die jeweilige taste "gedrückt worden"?
        If My.Computer.Keyboard.CapsLock Then
            keybd_event(VK_CAPITAL, 0, 0, 0)
            keybd_event(VK_CAPITAL, 0, KEYEVENTF_KEYUP2, 0)
        End If
        If My.Computer.Keyboard.NumLock Then
            keybd_event(VK_NUMLOCK, 0, 0, 0)
            keybd_event(VK_NUMLOCK, 0, KEYEVENTF_KEYUP2, 0)
        End If
        If My.Computer.Keyboard.ScrollLock Then
            keybd_event(VK_SCROLL, &H45, KEYEVENTF_EXTENDEDKEY3 Or 0, 0)
            keybd_event(VK_SCROLL, &H45, KEYEVENTF_EXTENDEDKEY3 Or KEYEVENTF_KEYUP3, 0)
        End If
    End Sub
    '</alle effekte aus>


    '<effekt interval>
    Private Sub Timer4_Tick(sender As Object, e As EventArgs) Handles Timer4.Tick
        keybd_event(VK_SCROLL, &H45, KEYEVENTF_EXTENDEDKEY3 Or 0, 0)
        keybd_event(VK_SCROLL, &H45, KEYEVENTF_EXTENDEDKEY3 Or KEYEVENTF_KEYUP3, 0)

        keybd_event(VK_CAPITAL, 0, 0, 0)
        keybd_event(VK_CAPITAL, 0, KEYEVENTF_KEYUP2, 0)

        keybd_event(VK_NUMLOCK, 0, 0, 0)
        keybd_event(VK_NUMLOCK, 0, KEYEVENTF_KEYUP2, 0)
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Timer4.Start()
    End Sub
    '</effekt interval>
End Class