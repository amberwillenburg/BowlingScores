Public Class Form1

    'I realize that this code has gotten very complex and long. If I had more time I would rework much
    'of this to be done with helper functions where the individual GUI components that need to be worked
    'with will just be passed in instead of writting that code for each one separately. The functionality
    'should be the same either way, but that would allow for cleaner code that would be easier to read and
    'follow. I regret not doing that from the very beginning. 

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    'These arrays store the individual frame values for each of the four players.
    'They start out with all zero values and get reset for as each frame gets calculated.
    'Once the frame values have been calculated, the total score up until that frame gets displayed
    'in that frame's text box, and is calculated by summing all previous frame values.
    'Index starts at 0 for frame 1 so the index of a given frame is always that frame - 1.
    Dim framevalues1(10) As Integer
    Dim framevalues2(10) As Integer
    Dim framevalues3(10) As Integer
    Dim framevalues4(10) As Integer

    'These lists keep track of which frames are spares or strikes. Then there is an easy way to look
    'back and determine if there is a frame that needs to be calculated yet because it's value was dependent on
    'the current frame. There are 4 pairs of lists so each player can be tracked individually.
    Dim spares1 As New List(Of Integer)()
    Dim strikes1 As New List(Of Integer)()
    Dim spares2 As New List(Of Integer)()
    Dim strikes2 As New List(Of Integer)()
    Dim spares3 As New List(Of Integer)()
    Dim strikes3 As New List(Of Integer)()
    Dim spares4 As New List(Of Integer)()
    Dim strikes4 As New List(Of Integer)()

    'The logic for the calculations of the frame values is split into cases.
    'This is the case when the current frame is a strike. The relavent textboxes get passed in
    'by the Calculate method along with the frame number and n, which corresponds to the player.
    Private Sub Strike(frame As Integer, ByRef prevbox As TextBox,
                          ByRef XXbox As TextBox, n As Integer)
        'First we check to see if there are any previous frames that need to be calculated based on this
        'one. If the previous frame is a spare, or if the previous frame, and potentially the one before that, 
        'were strikes. The frame values then get set accordingly, and the current frame just gets added
        'to the strikes list because it cannot yet be calculated. 
        If n = 1 Then
            If spares1.Contains(frame - 1) Then
                framevalues1(frame - 2) = 20
                prevbox.Text = findTotal(frame - 1, n)
            ElseIf strikes1.Contains(frame - 1) Then
                If strikes1.Contains(frame - 2) Then
                    framevalues1(frame - 3) = 30
                    XXbox.Text = findTotal(frame - 2, n)
                End If
            End If
            strikes1.Add(frame)
        ElseIf n = 2 Then
            If spares2.Contains(frame - 1) Then
                framevalues2(frame - 2) = 20
                prevbox.Text = findTotal(frame - 1, n)
            ElseIf strikes2.Contains(frame - 1) Then
                If strikes2.Contains(frame - 2) Then
                    framevalues2(frame - 3) = 30
                    XXbox.Text = findTotal(frame - 2, n)
                End If
            End If
            strikes2.Add(frame)
        ElseIf n = 3 Then
            If spares3.Contains(frame - 1) Then
                framevalues3(frame - 2) = 20
                prevbox.Text = findTotal(frame - 1, n)
            ElseIf strikes3.Contains(frame - 1) Then
                If strikes3.Contains(frame - 2) Then
                    framevalues3(frame - 3) = 30
                    XXbox.Text = findTotal(frame - 2, n)
                End If
            End If
            strikes3.Add(frame)
        ElseIf n = 4 Then
            If spares4.Contains(frame - 1) Then
                framevalues4(frame - 2) = 20
                prevbox.Text = findTotal(frame - 1, n)
            ElseIf strikes4.Contains(frame - 1) Then
                If strikes4.Contains(frame - 2) Then
                    framevalues4(frame - 3) = 30
                    XXbox.Text = findTotal(frame - 2, n)
                End If
            End If
            strikes4.Add(frame)
        Else
            'This should never happen
        End If
    End Sub

    'This method handles the calculations in the case that the current frame is a spare. The values that 
    'get passed in are the frame number and n, corresponding to the player, the textboxes that could 
    'be modified, and v1, the value in the first shot of the current frame.
    Private Sub Spare(frame As Integer, v1 As Integer, ByRef prevbox As TextBox,
                          ByRef XXbox As TextBox, n As Integer)
        'First any previous frames that need to be calculated are handled according to the scoring 
        'rules of bowling. Then the current frame is added to the spares list so that it will be 
        'calculated at a later time when the proper information is available.
        If n = 1 Then
            If spares1.Contains(frame - 1) Then
                framevalues1(frame - 2) = 10 + v1
                prevbox.Text = findTotal(frame - 1, n)
            ElseIf strikes1.Contains(frame - 1) Then
                If strikes1.Contains(frame - 2) Then
                    framevalues1(frame - 3) = 20 + v1
                    XXbox.Text = findTotal(frame - 2, n)
                End If
                framevalues1(frame - 2) = 20
                prevbox.Text = findTotal(frame - 1, n)
            End If
            spares1.Add(frame)
        ElseIf n = 2 Then
            If spares2.Contains(frame - 1) Then
                framevalues2(frame - 2) = 10 + v1
                prevbox.Text = findTotal(frame - 1, n)
            ElseIf strikes2.Contains(frame - 1) Then
                If strikes2.Contains(frame - 2) Then
                    framevalues2(frame - 3) = 20 + v1
                    XXbox.Text = findTotal(frame - 2, n)
                End If
                framevalues2(frame - 2) = 20
                prevbox.Text = findTotal(frame - 1, n)
            End If
            spares2.Add(frame)
        ElseIf n = 3 Then
            If spares3.Contains(frame - 1) Then
                framevalues3(frame - 2) = 10 + v1
                prevbox.Text = findTotal(frame - 1, n)
            ElseIf strikes3.Contains(frame - 1) Then
                If strikes3.Contains(frame - 2) Then
                    framevalues3(frame - 3) = 20 + v1
                    XXbox.Text = findTotal(frame - 2, n)
                End If
                framevalues3(frame - 2) = 20
                prevbox.Text = findTotal(frame - 1, n)
            End If
            spares3.Add(frame)
        ElseIf n = 4 Then
            If spares4.Contains(frame - 1) Then
                framevalues4(frame - 2) = 10 + v1
                prevbox.Text = findTotal(frame - 1, n)
            ElseIf strikes4.Contains(frame - 1) Then
                If strikes4.Contains(frame - 2) Then
                    framevalues4(frame - 3) = 20 + v1
                    XXbox.Text = findTotal(frame - 2, n)
                End If
                framevalues4(frame - 2) = 20
                prevbox.Text = findTotal(frame - 1, n)
            End If
            spares4.Add(frame)
        Else
            'this should never happen
        End If
    End Sub

    'This method handles the case where the current frame is an open frame. All relevant values get passed in
    'including the values of both shots in this frame, the textboxes of this frame and the previous two,
    'as well as numbers indicating the current frame and player.
    Private Sub OpenFrame(frame As Integer, v1 As Integer, v2 As Integer,
                          ByRef currentbox As TextBox, ByRef prevbox As TextBox,
                          ByRef XXbox As TextBox, n As Integer)
        'The previous two frames are checked to see if any spares or strikes exist that need to 
        'be calculated. Then the current frame value is calculated and all of the totals get printed.
        If n = 1 Then
            If spares1.Contains(frame - 1) Then
                framevalues1(frame - 2) = 10 + v1
                prevbox.Text = findTotal(frame - 1, n)
            ElseIf strikes1.Contains(frame - 1) Then
                If strikes1.Contains(frame - 2) Then
                    framevalues1(frame - 3) = 20 + v1
                    XXbox.Text = findTotal(frame - 2, n)
                End If
                framevalues1(frame - 2) = 10 + v1 + v2
                prevbox.Text = findTotal(frame - 1, n)
            End If
            framevalues1(frame - 1) = v1 + v2
            currentbox.Text = findTotal(frame, n)
        ElseIf n = 2 Then
            If spares2.Contains(frame - 1) Then
                framevalues2(frame - 2) = 10 + v1
                prevbox.Text = findTotal(frame - 1, n)
            ElseIf strikes2.Contains(frame - 1) Then
                If strikes2.Contains(frame - 2) Then
                    framevalues2(frame - 3) = 20 + v1
                    XXbox.Text = findTotal(frame - 2, n)
                End If
                framevalues2(frame - 2) = 10 + v1 + v2
                prevbox.Text = findTotal(frame - 1, n)
            End If
            framevalues2(frame - 1) = v1 + v2
            currentbox.Text = findTotal(frame, n)
        ElseIf n = 3 Then
            If spares3.Contains(frame - 1) Then
                framevalues3(frame - 2) = 10 + v1
                prevbox.Text = findTotal(frame - 1, n)
            ElseIf strikes3.Contains(frame - 1) Then
                If strikes3.Contains(frame - 2) Then
                    framevalues3(frame - 3) = 20 + v1
                    XXbox.Text = findTotal(frame - 2, n)
                End If
                framevalues3(frame - 2) = 10 + v1 + v2
                prevbox.Text = findTotal(frame - 1, n)
            End If
            framevalues3(frame - 1) = v1 + v2
            currentbox.Text = findTotal(frame, n)
        ElseIf n = 4 Then
            If spares4.Contains(frame - 1) Then
                framevalues4(frame - 2) = 10 + v1
                prevbox.Text = findTotal(frame - 1, n)
            ElseIf strikes4.Contains(frame - 1) Then
                If strikes4.Contains(frame - 2) Then
                    framevalues4(frame - 3) = 20 + v1
                    XXbox.Text = findTotal(frame - 2, n)
                End If
                framevalues4(frame - 2) = 10 + v1 + v2
                prevbox.Text = findTotal(frame - 1, n)
            End If
            framevalues4(frame - 1) = v1 + v2
            currentbox.Text = findTotal(frame, n)
        Else
            'this should never happen
        End If

    End Sub

    'This method handles the tenth frame only. The values of the three shots in the tenth frame,
    'the third value is just ignored in the case where no third shot was allowed, and the textboxes
    'for this and the previous two frames are passed in to be modified. The value n for the player is
    'also passed in.
    Private Sub TenthFrame(v1 As Integer, v2 As Integer, v3 As Integer,
                           ByRef currentbox As TextBox, ByRef prevbox As TextBox,
                           ByRef XXbox As TextBox, n As Integer)
        'If the first two values are less than 10, it is an open frame and the third shot is not
        'allowed, it then gets treated like any other open frame.
        If (v1 + v2 < 10) Then
            OpenFrame(10, v1, v2, currentbox, prevbox, XXbox, n)
            'if the first two values equal 10, then it can be treated as a spare in order to calculate
            'any previous values that were left uncalculated due to spares or strikes. The value for 
            'the current frame then gets set as just 10 + the last shot.
        ElseIf (v1 + v2 = 10) Then
            Spare(10, v1, prevbox, XXbox, n)
            If n = 1 Then
                framevalues1(9) = 10 + v3
            ElseIf n = 2 Then
                framevalues2(9) = 10 + v3
            ElseIf n = 3 Then
                framevalues3(9) = 10 + v3
            ElseIf n = 4 Then
                framevalues4(9) = 10 + v3
            Else
                'this should never happen
            End If
            currentbox.Text = findTotal(10, n)
            'if v1 + v2 is greater than 10, then we know that at least v1 is a strike. We then call
            'the strike method twice, with frame 10 and an artificial frame 11, just as a way to calculate
            'any previous frames that are necessary. Since this essentially tells the system that there
            'are two strikes in a row, even if v2 is not a strike, neither of these strikes would be calculated
            'as they would both need more information. Then the 10th frame can be calculated as 10 + v2 + v3
            'to account for the true value of v2, strike or not. 
        Else
            Strike(10, prevbox, XXbox, n)
            Strike(11, currentbox, prevbox, n)
            If n = 1 Then
                framevalues1(9) = 10 + v2 + v3
            ElseIf n = 2 Then
                framevalues2(9) = 10 + v2 + v3
            ElseIf n = 3 Then
                framevalues3(9) = 10 + v2 + v3
            ElseIf n = 4 Then
                framevalues4(9) = 10 + v2 + v3
            Else
                'this should never happen
            End If
            currentbox.Text = findTotal(10, n)
        End If
    End Sub

    'This is a function that returns the total for a given frame and player by looping through the 
    'framevalues array and summing up the previous values. This gets called when the value needs to 
    'be displayed in the textboxes.
    Private Function findTotal(frame As Integer, n As Integer)
        Dim total As Integer
        If n = 1 Then
            For i As Integer = 0 To (frame - 1) Step 1
                total += framevalues1(i)
            Next
        ElseIf n = 2 Then
            For i As Integer = 0 To (frame - 1) Step 1
                total += framevalues2(i)
            Next
        ElseIf n = 3 Then
            For i As Integer = 0 To (frame - 1) Step 1
                total += framevalues3(i)
            Next
        ElseIf n = 4 Then
            For i As Integer = 0 To (frame - 1) Step 1
                total += framevalues4(i)
            Next
        Else
            'this should never happen
        End If
        Return total
    End Function

    'This method determines what type of frame we currently have and calls the proper method based on that.
    'It also checks to see whether the current frame was previously deemed a spare or a strike in order 
    'to avoid issues with conflicting classifications on the same frame.
    Private Sub Calculate(ByRef currentbox As TextBox, ByRef prevbox As TextBox,
                          ByRef XXbox As TextBox, frame As Integer, v1 As Integer,
                          v2 As Integer, v3 As Integer, n As Integer)
        If (frame < 10) Then
            If (v1 + v2) < 10 Then
                If n = 1 Then
                    If strikes1.Contains(frame) Then
                        strikes1.Remove(frame)
                    ElseIf spares1.Contains(frame) Then
                        spares1.Remove(frame)
                    End If
                ElseIf n = 2 Then
                    If strikes2.Contains(frame) Then
                        strikes2.Remove(frame)
                    ElseIf spares2.Contains(frame) Then
                        spares2.Remove(frame)
                    End If
                ElseIf n = 3 Then
                    If strikes3.Contains(frame) Then
                        strikes3.Remove(frame)
                    ElseIf spares3.Contains(frame) Then
                        spares3.Remove(frame)
                    End If
                ElseIf n = 4 Then
                    If strikes4.Contains(frame) Then
                        strikes4.Remove(frame)
                    ElseIf spares4.Contains(frame) Then
                        spares4.Remove(frame)
                    End If
                Else
                    'this should never happen
                End If         
                OpenFrame(frame, v1, v2, currentbox, prevbox, XXbox, n)
            ElseIf v1 = 10 Then
                If n = 1 Then
                    If spares1.Contains(frame) Then
                        spares1.Remove(frame)
                    End If
                    framevalues1(frame - 1) = 0
                ElseIf n = 2 Then
                    If spares2.Contains(frame) Then
                        spares2.Remove(frame)
                    End If
                    framevalues2(frame - 1) = 0
                ElseIf n = 3 Then
                    If spares3.Contains(frame) Then
                        spares3.Remove(frame)
                    End If
                    framevalues3(frame - 1) = 0
                ElseIf n = 4 Then
                    If spares4.Contains(frame) Then
                        spares4.Remove(frame)
                    End If
                    framevalues4(frame - 1) = 0
                Else
                    'this should never happen
                End If
                Strike(frame, prevbox, XXbox, n)
                currentbox.Text = ""
            Else
                If n = 1 Then
                    If strikes1.Contains(frame) Then
                        strikes1.Remove(frame)
                    End If
                    framevalues1(frame - 1) = 0
                ElseIf n = 2 Then
                    If strikes2.Contains(frame) Then
                        strikes2.Remove(frame)
                    End If
                    framevalues2(frame - 1) = 0
                ElseIf n = 3 Then
                    If strikes3.Contains(frame) Then
                        strikes3.Remove(frame)
                    End If
                    framevalues3(frame - 1) = 0
                ElseIf n = 4 Then
                    If strikes4.Contains(frame) Then
                        strikes4.Remove(frame)
                    End If
                    framevalues4(frame - 1) = 0
                Else
                    'this should never happen
                End If
                Spare(frame, v1, prevbox, XXbox, n)
                currentbox.Text = ""
            End If
        Else
            TenthFrame(v1, v2, v3, currentbox, prevbox, XXbox, n)
        End If
        Recalculate(frame, n)
    End Sub

    'The recalculate method handles the case where the user has gone back to a previous frame and modified
    'the values. Anything before the modified value is handled already by the Spare, Strike, and Openframe
    'methods in normal calculation because during those calculations it is assumed that anything that depends
    'on the current frame simply hasn't been calculated. Altering the total for one frame however, alters
    'the total for any frames following it. This case is not handled in normal calculation and needs separate
    'cases to be checked. 
    Private Sub Recalculate(frame As Integer, n As Integer)
        If n = 1 Then
            'If a frame has not been entered before, we don't want to display any totals. If no value
            'has been selected, the selected index of the second shot combobox defaults to -1.
            'For whatever frame we are currently on, we check the following frames to see if they have 
            'been calculated or not, until we reach one that has not been calculated. (The comboboxes are
            'set as disabled until the previous one has been entered, so if one combobox has not been
            'entered, nothing passed it is able to.) If we find a frame that has been calculated, then
            'we recalculate the total by calling find total and print the result to the textbox.
            If frame = 1 Then
                If ComboBox121.SelectedIndex > -1 AndAlso ComboBox121.SelectedItem.Equals("X") Or ComboBox122.SelectedIndex > -1 Then
                    If strikes1.Contains(frame) Or spares1.Contains(frame) Then
                        Dim value1 As String
                        Dim value2 As String
                        Dim v1 As Integer
                        Dim v2 As Integer
                        value1 = ComboBox121.SelectedItem
                        value2 = ComboBox122.SelectedItem
                        If value1.Equals("X") Then
                            v1 = 10
                            v2 = 0
                        ElseIf value2.Equals("/") Then
                            v1 = CInt(value1)
                            v2 = 10 - v1
                        Else
                            v1 = CInt(value1)
                            v2 = CInt(value2)
                        End If
                        Calculate(TextBox12, TextBox11, TextBox11, 2, v1, v2, 0, 1)
                    End If
                    If Not ((strikes1.Contains(2) Or spares1.Contains(2)) And framevalues1(1) = 0) Then
                        TextBox12.Text = findTotal(2, 1)
                    End If
                    If ComboBox131.SelectedIndex > -1 AndAlso ComboBox131.SelectedItem.Equals("X") Or ComboBox132.SelectedIndex > -1 Then
                        If strikes1.Contains(frame) And strikes1.Contains(frame + 1) Then
                            Dim value1 As String
                            Dim value2 As String
                            Dim v1 As Integer
                            Dim v2 As Integer
                            value1 = ComboBox131.SelectedItem
                            value2 = ComboBox132.SelectedItem
                            If value1.Equals("X") Then
                                v1 = 10
                                v2 = 0
                            ElseIf value2.Equals("/") Then
                                v1 = CInt(value1)
                                v2 = 10 - v1
                            Else
                                v1 = CInt(value1)
                                v2 = CInt(value2)
                            End If
                            Calculate(TextBox13, TextBox12, TextBox11, 3, v1, v2, 0, 1)
                            If framevalues1(1) > 0 Then
                                TextBox12.Text = findTotal(2, 1)
                            End If
                        End If
                        If Not ((strikes1.Contains(3) Or spares1.Contains(3)) And framevalues1(2) = 0) Then
                            TextBox13.Text = findTotal(3, 1)
                        End If
                        If ComboBox141.SelectedIndex > -1 AndAlso ComboBox141.SelectedItem.Equals("X") Or ComboBox142.SelectedIndex > -1 Then
                            If Not ((strikes1.Contains(4) Or spares1.Contains(4)) And framevalues1(3) = 0) Then
                                TextBox14.Text = findTotal(4, 1)
                            End If
                            If ComboBox151.SelectedIndex > -1 AndAlso ComboBox151.SelectedItem.Equals("X") Or ComboBox152.SelectedIndex > -1 Then
                                If Not ((strikes1.Contains(5) Or spares1.Contains(5)) And framevalues1(4) = 0) Then
                                    TextBox15.Text = findTotal(5, 1)
                                End If
                                If ComboBox161.SelectedIndex > -1 AndAlso ComboBox161.SelectedItem.Equals("X") Or ComboBox162.SelectedIndex > -1 Then
                                    If Not ((strikes1.Contains(6) Or spares1.Contains(6)) And framevalues1(5) = 0) Then
                                        TextBox16.Text = findTotal(6, 1)
                                    End If
                                    If ComboBox171.SelectedIndex > -1 AndAlso ComboBox171.SelectedItem.Equals("X") Or ComboBox172.SelectedIndex > -1 Then
                                        If Not ((strikes1.Contains(7) Or spares1.Contains(7)) And framevalues1(6) = 0) Then
                                            TextBox17.Text = findTotal(7, 1)
                                        End If
                                        If ComboBox181.SelectedIndex > -1 AndAlso ComboBox181.SelectedItem.Equals("X") Or ComboBox182.SelectedIndex > -1 Then
                                            If Not ((strikes1.Contains(8) Or spares1.Contains(8)) And framevalues1(7) = 0) Then
                                                TextBox18.Text = findTotal(8, 1)
                                            End If
                                            If ComboBox191.SelectedIndex > -1 AndAlso ComboBox191.SelectedItem.Equals("X") Or ComboBox192.SelectedIndex > -1 Then
                                                If Not ((strikes1.Contains(9) Or spares1.Contains(9)) And framevalues1(8) = 0) Then
                                                    TextBox19.Text = findTotal(9, 1)
                                                End If
                                                If ComboBox1103.SelectedIndex > -1 Or ComboBox1102.SelectedIndex > -1 AndAlso
                                                   (Not ComboBox1101.SelectedItem.Equals("X") And Not ComboBox1102.SelectedItem.Equals("/")) Then
                                                    TextBox110.Text = findTotal(10, 1)
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            ElseIf frame = 2 Then
                If ComboBox131.SelectedIndex > -1 AndAlso ComboBox131.SelectedItem.Equals("X") Or ComboBox132.SelectedIndex > -1 Then
                    If strikes1.Contains(frame) Or spares1.Contains(frame) Then
                        Dim value1 As String
                        Dim value2 As String
                        Dim v1 As Integer
                        Dim v2 As Integer
                        value1 = ComboBox131.SelectedItem
                        value2 = ComboBox132.SelectedItem
                        If value1.Equals("X") Then
                            v1 = 10
                            v2 = 0
                        ElseIf value2.Equals("/") Then
                            v1 = CInt(value1)
                            v2 = 10 - v1
                        Else
                            v1 = CInt(value1)
                            v2 = CInt(value2)
                        End If
                        Calculate(TextBox13, TextBox12, TextBox11, 3, v1, v2, 0, 1)
                    End If
                    If Not ((strikes1.Contains(3) Or spares1.Contains(3)) And framevalues1(2) = 0) Then
                        TextBox13.Text = findTotal(3, 1)
                    End If
                    If ComboBox141.SelectedIndex > -1 AndAlso ComboBox141.SelectedItem.Equals("X") Or ComboBox142.SelectedIndex > -1 Then
                        If strikes1.Contains(frame) And strikes1.Contains(frame + 1) Then
                            Dim value1 As String
                            Dim value2 As String
                            Dim v1 As Integer
                            Dim v2 As Integer
                            value1 = ComboBox141.SelectedItem
                            value2 = ComboBox142.SelectedItem
                            If value1.Equals("X") Then
                                v1 = 10
                                v2 = 0
                            ElseIf value2.Equals("/") Then
                                v1 = CInt(value1)
                                v2 = 10 - v1
                            Else
                                v1 = CInt(value1)
                                v2 = CInt(value2)
                            End If
                            Calculate(TextBox14, TextBox13, TextBox12, 4, v1, v2, 0, 1)
                            If framevalues1(2) > 0 Then
                                TextBox13.Text = findTotal(3, 1)
                            End If
                        End If
                        If Not ((strikes1.Contains(4) Or spares1.Contains(4)) And framevalues1(3) = 0) Then
                            TextBox14.Text = findTotal(4, 1)
                        End If
                        If ComboBox151.SelectedIndex > -1 AndAlso ComboBox151.SelectedItem.Equals("X") Or ComboBox152.SelectedIndex > -1 Then
                            If Not ((strikes1.Contains(5) Or spares1.Contains(5)) And framevalues1(4) = 0) Then
                                TextBox15.Text = findTotal(5, 1)
                            End If
                            If ComboBox161.SelectedIndex > -1 AndAlso ComboBox161.SelectedItem.Equals("X") Or ComboBox162.SelectedIndex > -1 Then
                                If Not ((strikes1.Contains(6) Or spares1.Contains(6)) And framevalues1(5) = 0) Then
                                    TextBox16.Text = findTotal(6, 1)
                                End If
                                If ComboBox171.SelectedIndex > -1 AndAlso ComboBox171.SelectedItem.Equals("X") Or ComboBox172.SelectedIndex > -1 Then
                                    If Not ((strikes1.Contains(7) Or spares1.Contains(7)) And framevalues1(6) = 0) Then
                                        TextBox17.Text = findTotal(7, 1)
                                    End If
                                    If ComboBox181.SelectedIndex > -1 AndAlso ComboBox181.SelectedItem.Equals("X") Or ComboBox182.SelectedIndex > -1 Then
                                        If Not ((strikes1.Contains(8) Or spares1.Contains(8)) And framevalues1(7) = 0) Then
                                            TextBox18.Text = findTotal(8, 1)
                                        End If
                                        If ComboBox191.SelectedIndex > -1 AndAlso ComboBox191.SelectedItem.Equals("X") Or ComboBox192.SelectedIndex > -1 Then
                                            If Not ((strikes1.Contains(9) Or spares1.Contains(9)) And framevalues1(8) = 0) Then
                                                TextBox19.Text = findTotal(9, 1)
                                            End If
                                            If ComboBox1103.SelectedIndex > -1 Or ComboBox1102.SelectedIndex > -1 AndAlso
                                               (Not ComboBox1101.SelectedItem.Equals("X") And Not ComboBox1102.SelectedItem.Equals("/")) Then
                                                TextBox110.Text = findTotal(10, 1)
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            ElseIf frame = 3 Then
                If ComboBox141.SelectedIndex > -1 AndAlso ComboBox141.SelectedItem.Equals("X") Or ComboBox142.SelectedIndex > -1 Then
                    If strikes1.Contains(frame) Or spares1.Contains(frame) Then
                        Dim value1 As String
                        Dim value2 As String
                        Dim v1 As Integer
                        Dim v2 As Integer
                        value1 = ComboBox141.SelectedItem
                        value2 = ComboBox142.SelectedItem
                        If value1.Equals("X") Then
                            v1 = 10
                            v2 = 0
                        ElseIf value2.Equals("/") Then
                            v1 = CInt(value1)
                            v2 = 10 - v1
                        Else
                            v1 = CInt(value1)
                            v2 = CInt(value2)
                        End If
                        Calculate(TextBox14, TextBox13, TextBox12, 4, v1, v2, 0, 1)
                    End If
                    If Not ((strikes1.Contains(4) Or spares1.Contains(4)) And framevalues1(3) = 0) Then
                        TextBox14.Text = findTotal(4, 1)
                    End If
                    If ComboBox151.SelectedIndex > -1 AndAlso ComboBox151.SelectedItem.Equals("X") Or ComboBox152.SelectedIndex > -1 Then
                        If strikes1.Contains(frame) And strikes1.Contains(frame + 1) Then
                            Dim value1 As String
                            Dim value2 As String
                            Dim v1 As Integer
                            Dim v2 As Integer
                            value1 = ComboBox151.SelectedItem
                            value2 = ComboBox152.SelectedItem
                            If value1.Equals("X") Then
                                v1 = 10
                                v2 = 0
                            ElseIf value2.Equals("/") Then
                                v1 = CInt(value1)
                                v2 = 10 - v1
                            Else
                                v1 = CInt(value1)
                                v2 = CInt(value2)
                            End If
                            Calculate(TextBox15, TextBox14, TextBox13, 5, v1, v2, 0, 1)
                            If framevalues1(3) > 0 Then
                                TextBox14.Text = findTotal(4, 1)
                            End If
                        End If
                        If Not ((strikes1.Contains(5) Or spares1.Contains(5)) And framevalues1(4) = 0) Then
                            TextBox15.Text = findTotal(5, 1)
                        End If
                        If ComboBox161.SelectedIndex > -1 AndAlso ComboBox161.SelectedItem.Equals("X") Or ComboBox162.SelectedIndex > -1 Then
                            If Not ((strikes1.Contains(6) Or spares1.Contains(6)) And framevalues1(5) = 0) Then
                                TextBox16.Text = findTotal(6, 1)
                            End If
                            If ComboBox171.SelectedIndex > -1 AndAlso ComboBox171.SelectedItem.Equals("X") Or ComboBox172.SelectedIndex > -1 Then
                                If Not ((strikes1.Contains(7) Or spares1.Contains(7)) And framevalues1(6) = 0) Then
                                    TextBox17.Text = findTotal(7, 1)
                                End If
                                If ComboBox181.SelectedIndex > -1 AndAlso ComboBox181.SelectedItem.Equals("X") Or ComboBox182.SelectedIndex > -1 Then
                                    If Not ((strikes1.Contains(8) Or spares1.Contains(8)) And framevalues1(7) = 0) Then
                                        TextBox18.Text = findTotal(8, 1)
                                    End If
                                    If ComboBox191.SelectedIndex > -1 AndAlso ComboBox191.SelectedItem.Equals("X") Or ComboBox192.SelectedIndex > -1 Then
                                        If Not ((strikes1.Contains(9) Or spares1.Contains(9)) And framevalues1(8) = 0) Then
                                            TextBox19.Text = findTotal(9, 1)
                                        End If
                                        If ComboBox1103.SelectedIndex > -1 Or ComboBox1102.SelectedIndex > -1 AndAlso
                                            (Not ComboBox1101.SelectedItem.Equals("X") And Not ComboBox1102.SelectedItem.Equals("/")) Then
                                            TextBox110.Text = findTotal(10, 1)
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            ElseIf frame = 4 Then
                If ComboBox151.SelectedIndex > -1 AndAlso ComboBox151.SelectedItem.Equals("X") Or ComboBox152.SelectedIndex > -1 Then
                    If strikes1.Contains(frame) Or spares1.Contains(frame) Then
                        Dim value1 As String
                        Dim value2 As String
                        Dim v1 As Integer
                        Dim v2 As Integer
                        value1 = ComboBox151.SelectedItem
                        value2 = ComboBox152.SelectedItem
                        If value1.Equals("X") Then
                            v1 = 10
                            v2 = 0
                        ElseIf value2.Equals("/") Then
                            v1 = CInt(value1)
                            v2 = 10 - v1
                        Else
                            v1 = CInt(value1)
                            v2 = CInt(value2)
                        End If
                        Calculate(TextBox15, TextBox14, TextBox13, 5, v1, v2, 0, 1)
                    End If
                    If Not ((strikes1.Contains(5) Or spares1.Contains(5)) And framevalues1(4) = 0) Then
                        TextBox15.Text = findTotal(5, 1)
                    End If
                    If ComboBox161.SelectedIndex > -1 AndAlso ComboBox161.SelectedItem.Equals("X") Or ComboBox162.SelectedIndex > -1 Then
                        If strikes1.Contains(frame) And strikes1.Contains(frame + 1) Then
                            Dim value1 As String
                            Dim value2 As String
                            Dim v1 As Integer
                            Dim v2 As Integer
                            value1 = ComboBox161.SelectedItem
                            value2 = ComboBox162.SelectedItem
                            If value1.Equals("X") Then
                                v1 = 10
                                v2 = 0
                            ElseIf value2.Equals("/") Then
                                v1 = CInt(value1)
                                v2 = 10 - v1
                            Else
                                v1 = CInt(value1)
                                v2 = CInt(value2)
                            End If
                            Calculate(TextBox16, TextBox15, TextBox14, 6, v1, v2, 0, 1)
                            If framevalues1(4) > 0 Then
                                TextBox15.Text = findTotal(5, 1)
                            End If
                        End If
                        If Not ((strikes1.Contains(6) Or spares1.Contains(6)) And framevalues1(5) = 0) Then
                            TextBox16.Text = findTotal(6, 1)
                        End If
                        If ComboBox171.SelectedIndex > -1 AndAlso ComboBox171.SelectedItem.Equals("X") Or ComboBox172.SelectedIndex > -1 Then
                            If Not ((strikes1.Contains(7) Or spares1.Contains(7)) And framevalues1(6) = 0) Then
                                TextBox17.Text = findTotal(7, 1)
                            End If
                            If ComboBox181.SelectedIndex > -1 AndAlso ComboBox181.SelectedItem.Equals("X") Or ComboBox182.SelectedIndex > -1 Then
                                If Not ((strikes1.Contains(8) Or spares1.Contains(8)) And framevalues1(7) = 0) Then
                                    TextBox18.Text = findTotal(8, 1)
                                End If
                                If ComboBox191.SelectedIndex > -1 AndAlso ComboBox191.SelectedItem.Equals("X") Or ComboBox192.SelectedIndex > -1 Then
                                    If Not ((strikes1.Contains(9) Or spares1.Contains(9)) And framevalues1(8) = 0) Then
                                        TextBox19.Text = findTotal(9, 1)
                                    End If
                                    If ComboBox1103.SelectedIndex > -1 Or ComboBox1102.SelectedIndex > -1 AndAlso
                                      (Not ComboBox1101.SelectedItem.Equals("X") And Not ComboBox1102.SelectedItem.Equals("/")) Then
                                        TextBox110.Text = findTotal(10, 1)
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            ElseIf frame = 5 Then
                If ComboBox161.SelectedIndex > -1 AndAlso ComboBox161.SelectedItem.Equals("X") Or ComboBox162.SelectedIndex > -1 Then
                    If strikes1.Contains(frame) Or spares1.Contains(frame) Then
                        Dim value1 As String
                        Dim value2 As String
                        Dim v1 As Integer
                        Dim v2 As Integer
                        value1 = ComboBox161.SelectedItem
                        value2 = ComboBox162.SelectedItem
                        If value1.Equals("X") Then
                            v1 = 10
                            v2 = 0
                        ElseIf value2.Equals("/") Then
                            v1 = CInt(value1)
                            v2 = 10 - v1
                        Else
                            v1 = CInt(value1)
                            v2 = CInt(value2)
                        End If
                        Calculate(TextBox16, TextBox15, TextBox14, 6, v1, v2, 0, 1)
                    End If
                    If Not ((strikes1.Contains(6) Or spares1.Contains(6)) And framevalues1(5) = 0) Then
                        TextBox16.Text = findTotal(6, 1)
                    End If
                    If ComboBox171.SelectedIndex > -1 AndAlso ComboBox171.SelectedItem.Equals("X") Or ComboBox172.SelectedIndex > -1 Then
                        If strikes1.Contains(frame) And strikes1.Contains(frame + 1) Then
                            Dim value1 As String
                            Dim value2 As String
                            Dim v1 As Integer
                            Dim v2 As Integer
                            value1 = ComboBox171.SelectedItem
                            value2 = ComboBox172.SelectedItem
                            If value1.Equals("X") Then
                                v1 = 10
                                v2 = 0
                            ElseIf value2.Equals("/") Then
                                v1 = CInt(value1)
                                v2 = 10 - v1
                            Else
                                v1 = CInt(value1)
                                v2 = CInt(value2)
                            End If
                            Calculate(TextBox17, TextBox16, TextBox15, 7, v1, v2, 0, 1)
                            If framevalues1(5) > 0 Then
                                TextBox16.Text = findTotal(6, 1)
                            End If
                        End If
                        If Not ((strikes1.Contains(7) Or spares1.Contains(7)) And framevalues1(6) = 0) Then
                            TextBox17.Text = findTotal(7, 1)
                        End If
                        If ComboBox181.SelectedIndex > -1 AndAlso ComboBox181.SelectedItem.Equals("X") Or ComboBox182.SelectedIndex > -1 Then
                            If Not ((strikes1.Contains(8) Or spares1.Contains(8)) And framevalues1(7) = 0) Then
                                TextBox18.Text = findTotal(8, 1)
                            End If
                            If ComboBox191.SelectedIndex > -1 AndAlso ComboBox191.SelectedItem.Equals("X") Or ComboBox192.SelectedIndex > -1 Then
                                If Not ((strikes1.Contains(9) Or spares1.Contains(9)) And framevalues1(8) = 0) Then
                                    TextBox19.Text = findTotal(9, 1)
                                End If
                                If ComboBox1103.SelectedIndex > -1 Or ComboBox1102.SelectedIndex > -1 AndAlso
                                    (Not ComboBox1101.SelectedItem.Equals("X") And Not ComboBox1102.SelectedItem.Equals("/")) Then
                                    TextBox110.Text = findTotal(10, 1)
                                End If
                            End If
                        End If
                    End If
                End If
            ElseIf frame = 6 Then
                If ComboBox171.SelectedIndex > -1 AndAlso ComboBox171.SelectedItem.Equals("X") Or ComboBox172.SelectedIndex > -1 Then
                    If strikes1.Contains(frame) Or spares1.Contains(frame) Then
                        Dim value1 As String
                        Dim value2 As String
                        Dim v1 As Integer
                        Dim v2 As Integer
                        value1 = ComboBox171.SelectedItem
                        value2 = ComboBox172.SelectedItem
                        If value1.Equals("X") Then
                            v1 = 10
                            v2 = 0
                        ElseIf value2.Equals("/") Then
                            v1 = CInt(value1)
                            v2 = 10 - v1
                        Else
                            v1 = CInt(value1)
                            v2 = CInt(value2)
                        End If
                        Calculate(TextBox17, TextBox16, TextBox15, 7, v1, v2, 0, 1)
                    End If
                    If Not ((strikes1.Contains(7) Or spares1.Contains(7)) And framevalues1(6) = 0) Then
                        TextBox17.Text = findTotal(7, 1)
                    End If
                    If ComboBox181.SelectedIndex > -1 AndAlso ComboBox181.SelectedItem.Equals("X") Or ComboBox182.SelectedIndex > -1 Then
                        If strikes1.Contains(frame) And strikes1.Contains(frame + 1) Then
                            Dim value1 As String
                            Dim value2 As String
                            Dim v1 As Integer
                            Dim v2 As Integer
                            value1 = ComboBox181.SelectedItem
                            value2 = ComboBox182.SelectedItem
                            If value1.Equals("X") Then
                                v1 = 10
                                v2 = 0
                            ElseIf value2.Equals("/") Then
                                v1 = CInt(value1)
                                v2 = 10 - v1
                            Else
                                v1 = CInt(value1)
                                v2 = CInt(value2)
                            End If
                            Calculate(TextBox18, TextBox17, TextBox16, 8, v1, v2, 0, 1)
                            If framevalues1(6) > 0 Then
                                TextBox17.Text = findTotal(7, 1)
                            End If
                        End If
                        If Not ((strikes1.Contains(8) Or spares1.Contains(8)) And framevalues1(7) = 0) Then
                            TextBox18.Text = findTotal(8, 1)
                        End If
                        If ComboBox191.SelectedIndex > -1 AndAlso ComboBox191.SelectedItem.Equals("X") Or ComboBox192.SelectedIndex > -1 Then
                            If Not ((strikes1.Contains(9) Or spares1.Contains(9)) And framevalues1(8) = 0) Then
                                TextBox19.Text = findTotal(9, 1)
                            End If
                            If ComboBox1103.SelectedIndex > -1 Or ComboBox1102.SelectedIndex > -1 AndAlso
                              (Not ComboBox1101.SelectedItem.Equals("X") And Not ComboBox1102.SelectedItem.Equals("/")) Then
                                TextBox110.Text = findTotal(10, 1)
                            End If
                        End If
                    End If
                End If
            ElseIf frame = 7 Then
                If ComboBox181.SelectedIndex > -1 AndAlso ComboBox181.SelectedItem.Equals("X") Or ComboBox182.SelectedIndex > -1 Then
                    If strikes1.Contains(frame) Or spares1.Contains(frame) Then
                        Dim value1 As String
                        Dim value2 As String
                        Dim v1 As Integer
                        Dim v2 As Integer
                        value1 = ComboBox181.SelectedItem
                        value2 = ComboBox182.SelectedItem
                        If value1.Equals("X") Then
                            v1 = 10
                            v2 = 0
                        ElseIf value2.Equals("/") Then
                            v1 = CInt(value1)
                            v2 = 10 - v1
                        Else
                            v1 = CInt(value1)
                            v2 = CInt(value2)
                        End If
                        Calculate(TextBox18, TextBox17, TextBox16, 8, v1, v2, 0, 1)
                    End If
                    If Not ((strikes1.Contains(8) Or spares1.Contains(8)) And framevalues1(7) = 0) Then
                        TextBox18.Text = findTotal(8, 1)
                    End If
                    If ComboBox191.SelectedIndex > -1 AndAlso ComboBox191.SelectedItem.Equals("X") Or ComboBox192.SelectedIndex > -1 Then
                        If strikes1.Contains(frame) And strikes1.Contains(frame + 1) Then
                            Dim value1 As String
                            Dim value2 As String
                            Dim v1 As Integer
                            Dim v2 As Integer
                            value1 = ComboBox191.SelectedItem
                            value2 = ComboBox192.SelectedItem
                            If value1.Equals("X") Then
                                v1 = 10
                                v2 = 0
                            ElseIf value2.Equals("/") Then
                                v1 = CInt(value1)
                                v2 = 10 - v1
                            Else
                                v1 = CInt(value1)
                                v2 = CInt(value2)
                            End If
                            Calculate(TextBox19, TextBox18, TextBox17, 9, v1, v2, 0, 1)
                            If framevalues1(7) > 0 Then
                                TextBox18.Text = findTotal(8, 1)
                            End If
                        End If
                        If Not ((strikes1.Contains(9) Or spares1.Contains(9)) And framevalues1(8) = 0) Then
                            TextBox19.Text = findTotal(9, 1)
                        End If
                        If ComboBox1103.SelectedIndex > -1 Or ComboBox1102.SelectedIndex > -1 AndAlso
                          (Not ComboBox1101.SelectedItem.Equals("X") And Not ComboBox1102.SelectedItem.Equals("/")) Then
                            TextBox110.Text = findTotal(10, 1)
                        End If
                    End If
                End If
            ElseIf frame = 8 Then
                If ComboBox191.SelectedIndex > -1 AndAlso ComboBox191.SelectedItem.Equals("X") Or ComboBox192.SelectedIndex > -1 Then
                    If strikes1.Contains(frame) Or spares1.Contains(frame) Then
                        Dim value1 As String
                        Dim value2 As String
                        Dim v1 As Integer
                        Dim v2 As Integer
                        value1 = ComboBox191.SelectedItem
                        value2 = ComboBox192.SelectedItem
                        If value1.Equals("X") Then
                            v1 = 10
                            v2 = 0
                        ElseIf value2.Equals("/") Then
                            v1 = CInt(value1)
                            v2 = 10 - v1
                        Else
                            v1 = CInt(value1)
                            v2 = CInt(value2)
                        End If
                        Calculate(TextBox19, TextBox18, TextBox17, 9, v1, v2, 0, 1)
                    End If
                    If Not ((strikes1.Contains(9) Or spares1.Contains(9)) And framevalues1(8) = 0) Then
                        TextBox19.Text = findTotal(9, 1)
                    End If
                    If ComboBox1103.SelectedIndex > -1 Or ComboBox1102.SelectedIndex > -1 AndAlso
                     (Not ComboBox1101.SelectedItem.Equals("X") And Not ComboBox1102.SelectedItem.Equals("/")) Then
                        If strikes1.Contains(frame) And strikes1.Contains(frame + 1) Then
                            Dim value1 As String
                            Dim value2 As String
                            Dim value3 As String
                            Dim v1 As Integer
                            Dim v2 As Integer
                            Dim v3 As Integer
                            value1 = ComboBox1101.SelectedItem
                            value2 = ComboBox1102.SelectedItem
                            value3 = ComboBox1103.SelectedItem
                            If value1.Equals("X") Then
                                v1 = 10
                            Else
                                v1 = CInt(value1)
                            End If

                            If value2.Equals("X") Then
                                v2 = 10
                            ElseIf value2.Equals("/") Then
                                v2 = 10 - v1
                            Else
                                v2 = CInt(value2)
                            End If

                            If value3.Equals("X") Then
                                v3 = 10
                            ElseIf value3.Equals("/") Then
                                v3 = 10 - v2
                            Else
                                v3 = CInt(value3)
                            End If
                            Calculate(TextBox110, TextBox19, TextBox18, 10, v1, v2, v3, 1)
                            If framevalues1(8) > 0 Then
                                TextBox19.Text = findTotal(9, 1)
                            End If
                        End If
                        TextBox110.Text = findTotal(10, 1)
                    End If
                End If
            ElseIf frame = 9 Then
                If ComboBox1103.SelectedIndex > -1 Or ComboBox1102.SelectedIndex > -1 AndAlso
                    (Not ComboBox1101.SelectedItem.Equals("X") And Not ComboBox1102.SelectedItem.Equals("/")) Then
                    If strikes1.Contains(frame) Or spares1.Contains(frame) Then
                        Dim value1 As String
                        Dim value2 As String
                        Dim value3 As String
                        Dim v1 As Integer
                        Dim v2 As Integer
                        Dim v3 As Integer
                        value1 = ComboBox1101.SelectedItem
                        value2 = ComboBox1102.SelectedItem
                        value3 = ComboBox1103.SelectedItem
                        If value1.Equals("X") Then
                            v1 = 10
                        Else
                            v1 = CInt(value1)
                        End If

                        If value2.Equals("X") Then
                            v2 = 10
                        ElseIf value2.Equals("/") Then
                            v2 = 10 - v1
                        Else
                            v2 = CInt(value2)
                        End If

                        If value3.Equals("X") Then
                            v3 = 10
                        ElseIf value3.Equals("/") Then
                            v3 = 10 - v2
                        Else
                            v3 = CInt(value3)
                        End If
                        Calculate(TextBox110, TextBox19, TextBox18, 10, v1, v2, v3, 1)
                    End If
                    TextBox110.Text = findTotal(10, 1)
                End If
            Else
                'this should never happen
            End If
        ElseIf n = 2 Then
            If frame = 1 Then
                If ComboBox221.SelectedIndex > -1 AndAlso ComboBox221.SelectedItem.Equals("X") Or ComboBox222.SelectedIndex > -1 Then
                    If strikes2.Contains(frame) Or spares2.Contains(frame) Then
                        Dim value1 As String
                        Dim value2 As String
                        Dim v1 As Integer
                        Dim v2 As Integer
                        value1 = ComboBox221.SelectedItem
                        value2 = ComboBox222.SelectedItem
                        If value1.Equals("X") Then
                            v1 = 10
                            v2 = 0
                        ElseIf value2.Equals("/") Then
                            v1 = CInt(value1)
                            v2 = 10 - v1
                        Else
                            v1 = CInt(value1)
                            v2 = CInt(value2)
                        End If
                        Calculate(TextBox22, TextBox21, TextBox21, 2, v1, v2, 0, 2)
                    End If
                    If Not ((strikes2.Contains(2) Or spares2.Contains(2)) And framevalues2(1) = 0) Then
                        TextBox22.Text = findTotal(2, 2)
                    End If
                    If ComboBox231.SelectedIndex > -1 AndAlso ComboBox231.SelectedItem.Equals("X") Or ComboBox232.SelectedIndex > -1 Then
                        If strikes2.Contains(frame) And strikes2.Contains(frame + 1) Then
                            Dim value1 As String
                            Dim value2 As String
                            Dim v1 As Integer
                            Dim v2 As Integer
                            value1 = ComboBox231.SelectedItem
                            value2 = ComboBox232.SelectedItem
                            If value1.Equals("X") Then
                                v1 = 10
                                v2 = 0
                            ElseIf value2.Equals("/") Then
                                v1 = CInt(value1)
                                v2 = 10 - v1
                            Else
                                v1 = CInt(value1)
                                v2 = CInt(value2)
                            End If
                            Calculate(TextBox23, TextBox22, TextBox21, 3, v1, v2, 0, 2)
                            If framevalues2(1) > 0 Then
                                TextBox22.Text = findTotal(2, 2)
                            End If
                        End If
                        If Not ((strikes2.Contains(3) Or spares2.Contains(3)) And framevalues2(2) = 0) Then
                            TextBox23.Text = findTotal(3, 2)
                        End If
                        If ComboBox241.SelectedIndex > -1 AndAlso ComboBox241.SelectedItem.Equals("X") Or ComboBox242.SelectedIndex > -1 Then
                            If Not ((strikes2.Contains(4) Or spares2.Contains(4)) And framevalues2(3) = 0) Then
                                TextBox24.Text = findTotal(4, 2)
                            End If
                            If ComboBox251.SelectedIndex > -1 AndAlso ComboBox251.SelectedItem.Equals("X") Or ComboBox252.SelectedIndex > -1 Then
                                If Not ((strikes2.Contains(5) Or spares2.Contains(5)) And framevalues2(4) = 0) Then
                                    TextBox25.Text = findTotal(5, 2)
                                End If
                                If ComboBox261.SelectedIndex > -1 AndAlso ComboBox261.SelectedItem.Equals("X") Or ComboBox262.SelectedIndex > -1 Then
                                    If Not ((strikes2.Contains(6) Or spares2.Contains(6)) And framevalues2(5) = 0) Then
                                        TextBox26.Text = findTotal(6, 2)
                                    End If
                                    If ComboBox271.SelectedIndex > -1 AndAlso ComboBox271.SelectedItem.Equals("X") Or ComboBox272.SelectedIndex > -1 Then
                                        If Not ((strikes2.Contains(7) Or spares2.Contains(7)) And framevalues2(6) = 0) Then
                                            TextBox27.Text = findTotal(7, 2)
                                        End If
                                        If ComboBox281.SelectedIndex > -1 AndAlso ComboBox281.SelectedItem.Equals("X") Or ComboBox282.SelectedIndex > -1 Then
                                            If Not ((strikes2.Contains(8) Or spares2.Contains(8)) And framevalues2(7) = 0) Then
                                                TextBox28.Text = findTotal(8, 2)
                                            End If
                                            If ComboBox291.SelectedIndex > -1 AndAlso ComboBox291.SelectedItem.Equals("X") Or ComboBox292.SelectedIndex > -1 Then
                                                If Not ((strikes2.Contains(9) Or spares2.Contains(9)) And framevalues2(8) = 0) Then
                                                    TextBox29.Text = findTotal(9, 2)
                                                End If
                                                If ComboBox2103.SelectedIndex > -1 Or ComboBox2102.SelectedIndex > -1 AndAlso
                                                   (Not ComboBox2101.SelectedItem.Equals("X") And Not ComboBox2102.SelectedItem.Equals("/")) Then
                                                    TextBox210.Text = findTotal(10, 2)
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            ElseIf frame = 2 Then
                If ComboBox231.SelectedIndex > -1 AndAlso ComboBox231.SelectedItem.Equals("X") Or ComboBox232.SelectedIndex > -1 Then
                    If strikes2.Contains(frame) Or spares2.Contains(frame) Then
                        Dim value1 As String
                        Dim value2 As String
                        Dim v1 As Integer
                        Dim v2 As Integer
                        value1 = ComboBox231.SelectedItem
                        value2 = ComboBox232.SelectedItem
                        If value1.Equals("X") Then
                            v1 = 10
                            v2 = 0
                        ElseIf value2.Equals("/") Then
                            v1 = CInt(value1)
                            v2 = 10 - v1
                        Else
                            v1 = CInt(value1)
                            v2 = CInt(value2)
                        End If
                        Calculate(TextBox23, TextBox22, TextBox21, 3, v1, v2, 0, 2)
                    End If
                    If Not ((strikes2.Contains(3) Or spares2.Contains(3)) And framevalues2(2) = 0) Then
                        TextBox23.Text = findTotal(3, 2)
                    End If
                    If ComboBox241.SelectedIndex > -1 AndAlso ComboBox241.SelectedItem.Equals("X") Or ComboBox242.SelectedIndex > -1 Then
                        If strikes2.Contains(frame) And strikes2.Contains(frame + 1) Then
                            Dim value1 As String
                            Dim value2 As String
                            Dim v1 As Integer
                            Dim v2 As Integer
                            value1 = ComboBox241.SelectedItem
                            value2 = ComboBox242.SelectedItem
                            If value1.Equals("X") Then
                                v1 = 10
                                v2 = 0
                            ElseIf value2.Equals("/") Then
                                v1 = CInt(value1)
                                v2 = 10 - v1
                            Else
                                v1 = CInt(value1)
                                v2 = CInt(value2)
                            End If
                            Calculate(TextBox24, TextBox23, TextBox22, 4, v1, v2, 0, 2)
                            If framevalues2(2) > 0 Then
                                TextBox23.Text = findTotal(3, 2)
                            End If
                        End If
                        If Not ((strikes2.Contains(4) Or spares2.Contains(4)) And framevalues2(3) = 0) Then
                            TextBox24.Text = findTotal(4, 2)
                        End If
                        If ComboBox251.SelectedIndex > -1 AndAlso ComboBox251.SelectedItem.Equals("X") Or ComboBox252.SelectedIndex > -1 Then
                            If Not ((strikes2.Contains(5) Or spares2.Contains(5)) And framevalues2(4) = 0) Then
                                TextBox25.Text = findTotal(5, 2)
                            End If
                            If ComboBox261.SelectedIndex > -1 AndAlso ComboBox261.SelectedItem.Equals("X") Or ComboBox262.SelectedIndex > -1 Then
                                If Not ((strikes2.Contains(6) Or spares2.Contains(6)) And framevalues2(5) = 0) Then
                                    TextBox26.Text = findTotal(6, 2)
                                End If
                                If ComboBox271.SelectedIndex > -1 AndAlso ComboBox271.SelectedItem.Equals("X") Or ComboBox272.SelectedIndex > -1 Then
                                    If Not ((strikes2.Contains(7) Or spares2.Contains(7)) And framevalues2(6) = 0) Then
                                        TextBox27.Text = findTotal(7, 2)
                                    End If
                                    If ComboBox281.SelectedIndex > -1 AndAlso ComboBox281.SelectedItem.Equals("X") Or ComboBox282.SelectedIndex > -1 Then
                                        If Not ((strikes2.Contains(8) Or spares2.Contains(8)) And framevalues2(7) = 0) Then
                                            TextBox28.Text = findTotal(8, 2)
                                        End If
                                        If ComboBox291.SelectedIndex > -1 AndAlso ComboBox291.SelectedItem.Equals("X") Or ComboBox292.SelectedIndex > -1 Then
                                            If Not ((strikes2.Contains(9) Or spares2.Contains(9)) And framevalues2(8) = 0) Then
                                                TextBox29.Text = findTotal(9, 2)
                                            End If
                                            If ComboBox2103.SelectedIndex > -1 Or ComboBox2102.SelectedIndex > -1 AndAlso
                                               (Not ComboBox2101.SelectedItem.Equals("X") And Not ComboBox2102.SelectedItem.Equals("/")) Then
                                                TextBox210.Text = findTotal(10, 2)
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            ElseIf frame = 3 Then
                If ComboBox241.SelectedIndex > -1 AndAlso ComboBox241.SelectedItem.Equals("X") Or ComboBox242.SelectedIndex > -1 Then
                    If strikes2.Contains(frame) Or spares2.Contains(frame) Then
                        Dim value1 As String
                        Dim value2 As String
                        Dim v1 As Integer
                        Dim v2 As Integer
                        value1 = ComboBox241.SelectedItem
                        value2 = ComboBox242.SelectedItem
                        If value1.Equals("X") Then
                            v1 = 10
                            v2 = 0
                        ElseIf value2.Equals("/") Then
                            v1 = CInt(value1)
                            v2 = 10 - v1
                        Else
                            v1 = CInt(value1)
                            v2 = CInt(value2)
                        End If
                        Calculate(TextBox24, TextBox23, TextBox22, 4, v1, v2, 0, 2)
                    End If
                    If Not ((strikes2.Contains(4) Or spares2.Contains(4)) And framevalues2(3) = 0) Then
                        TextBox24.Text = findTotal(4, 2)
                    End If
                    If ComboBox251.SelectedIndex > -1 AndAlso ComboBox251.SelectedItem.Equals("X") Or ComboBox252.SelectedIndex > -1 Then
                        If strikes2.Contains(frame) And strikes2.Contains(frame + 1) Then
                            Dim value1 As String
                            Dim value2 As String
                            Dim v1 As Integer
                            Dim v2 As Integer
                            value1 = ComboBox251.SelectedItem
                            value2 = ComboBox252.SelectedItem
                            If value1.Equals("X") Then
                                v1 = 10
                                v2 = 0
                            ElseIf value2.Equals("/") Then
                                v1 = CInt(value1)
                                v2 = 10 - v1
                            Else
                                v1 = CInt(value1)
                                v2 = CInt(value2)
                            End If
                            Calculate(TextBox25, TextBox24, TextBox23, 5, v1, v2, 0, 2)
                            If framevalues2(3) > 0 Then
                                TextBox24.Text = findTotal(4, 2)
                            End If
                        End If
                        If Not ((strikes2.Contains(5) Or spares2.Contains(5)) And framevalues2(4) = 0) Then
                            TextBox25.Text = findTotal(5, 2)
                        End If
                        If ComboBox261.SelectedIndex > -1 AndAlso ComboBox261.SelectedItem.Equals("X") Or ComboBox262.SelectedIndex > -1 Then
                            If Not ((strikes2.Contains(6) Or spares2.Contains(6)) And framevalues2(5) = 0) Then
                                TextBox26.Text = findTotal(6, 2)
                            End If
                            If ComboBox271.SelectedIndex > -1 AndAlso ComboBox271.SelectedItem.Equals("X") Or ComboBox272.SelectedIndex > -1 Then
                                If Not ((strikes2.Contains(7) Or spares2.Contains(7)) And framevalues2(6) = 0) Then
                                    TextBox27.Text = findTotal(7, 2)
                                End If
                                If ComboBox281.SelectedIndex > -1 AndAlso ComboBox281.SelectedItem.Equals("X") Or ComboBox282.SelectedIndex > -1 Then
                                    If Not ((strikes2.Contains(8) Or spares2.Contains(8)) And framevalues2(7) = 0) Then
                                        TextBox28.Text = findTotal(8, 2)
                                    End If
                                    If ComboBox291.SelectedIndex > -1 AndAlso ComboBox291.SelectedItem.Equals("X") Or ComboBox292.SelectedIndex > -1 Then
                                        If Not ((strikes2.Contains(9) Or spares2.Contains(9)) And framevalues2(8) = 0) Then
                                            TextBox29.Text = findTotal(9, 2)
                                        End If
                                        If ComboBox2103.SelectedIndex > -1 Or ComboBox2102.SelectedIndex > -1 AndAlso
                                           (Not ComboBox2101.SelectedItem.Equals("X") And Not ComboBox2102.SelectedItem.Equals("/")) Then
                                            TextBox210.Text = findTotal(10, 2)
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            ElseIf frame = 4 Then
                If ComboBox251.SelectedIndex > -1 AndAlso ComboBox251.SelectedItem.Equals("X") Or ComboBox252.SelectedIndex > -1 Then
                    If strikes2.Contains(frame) Or spares2.Contains(frame) Then
                        Dim value1 As String
                        Dim value2 As String
                        Dim v1 As Integer
                        Dim v2 As Integer
                        value1 = ComboBox251.SelectedItem
                        value2 = ComboBox252.SelectedItem
                        If value1.Equals("X") Then
                            v1 = 10
                            v2 = 0
                        ElseIf value2.Equals("/") Then
                            v1 = CInt(value1)
                            v2 = 10 - v1
                        Else
                            v1 = CInt(value1)
                            v2 = CInt(value2)
                        End If
                        Calculate(TextBox25, TextBox24, TextBox23, 5, v1, v2, 0, 2)
                    End If
                    If Not ((strikes2.Contains(5) Or spares2.Contains(5)) And framevalues2(4) = 0) Then
                        TextBox25.Text = findTotal(5, 2)
                    End If
                    If ComboBox261.SelectedIndex > -1 AndAlso ComboBox261.SelectedItem.Equals("X") Or ComboBox262.SelectedIndex > -1 Then
                        If strikes2.Contains(frame) And strikes2.Contains(frame + 1) Then
                            Dim value1 As String
                            Dim value2 As String
                            Dim v1 As Integer
                            Dim v2 As Integer
                            value1 = ComboBox261.SelectedItem
                            value2 = ComboBox262.SelectedItem
                            If value1.Equals("X") Then
                                v1 = 10
                                v2 = 0
                            ElseIf value2.Equals("/") Then
                                v1 = CInt(value1)
                                v2 = 10 - v1
                            Else
                                v1 = CInt(value1)
                                v2 = CInt(value2)
                            End If
                            Calculate(TextBox26, TextBox25, TextBox24, 6, v1, v2, 0, 2)
                            If framevalues2(4) > 0 Then
                                TextBox25.Text = findTotal(5, 2)
                            End If
                        End If
                        If Not ((strikes2.Contains(6) Or spares2.Contains(6)) And framevalues2(5) = 0) Then
                            TextBox26.Text = findTotal(6, 2)
                        End If
                        If ComboBox271.SelectedIndex > -1 AndAlso ComboBox271.SelectedItem.Equals("X") Or ComboBox272.SelectedIndex > -1 Then
                            If Not ((strikes2.Contains(7) Or spares2.Contains(7)) And framevalues2(6) = 0) Then
                                TextBox27.Text = findTotal(7, 2)
                            End If
                            If ComboBox281.SelectedIndex > -1 AndAlso ComboBox281.SelectedItem.Equals("X") Or ComboBox282.SelectedIndex > -1 Then
                                If Not ((strikes2.Contains(8) Or spares2.Contains(8)) And framevalues2(7) = 0) Then
                                    TextBox28.Text = findTotal(8, 2)
                                End If
                                If ComboBox291.SelectedIndex > -1 AndAlso ComboBox291.SelectedItem.Equals("X") Or ComboBox292.SelectedIndex > -1 Then
                                    If Not ((strikes2.Contains(9) Or spares2.Contains(9)) And framevalues2(8) = 0) Then
                                        TextBox29.Text = findTotal(9, 2)
                                    End If
                                    If ComboBox2103.SelectedIndex > -1 Or ComboBox2102.SelectedIndex > -1 AndAlso
                                       (Not ComboBox2101.SelectedItem.Equals("X") And Not ComboBox2102.SelectedItem.Equals("/")) Then
                                        TextBox210.Text = findTotal(10, 2)
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            ElseIf frame = 5 Then
                If ComboBox261.SelectedIndex > -1 AndAlso ComboBox261.SelectedItem.Equals("X") Or ComboBox262.SelectedIndex > -1 Then
                    If strikes2.Contains(frame) Or spares2.Contains(frame) Then
                        Dim value1 As String
                        Dim value2 As String
                        Dim v1 As Integer
                        Dim v2 As Integer
                        value1 = ComboBox261.SelectedItem
                        value2 = ComboBox262.SelectedItem
                        If value1.Equals("X") Then
                            v1 = 10
                            v2 = 0
                        ElseIf value2.Equals("/") Then
                            v1 = CInt(value1)
                            v2 = 10 - v1
                        Else
                            v1 = CInt(value1)
                            v2 = CInt(value2)
                        End If
                        Calculate(TextBox26, TextBox25, TextBox24, 6, v1, v2, 0, 2)
                    End If
                    If Not ((strikes2.Contains(6) Or spares2.Contains(6)) And framevalues2(5) = 0) Then
                        TextBox26.Text = findTotal(6, 2)
                    End If
                    If ComboBox271.SelectedIndex > -1 AndAlso ComboBox271.SelectedItem.Equals("X") Or ComboBox272.SelectedIndex > -1 Then
                        If strikes2.Contains(frame) And strikes2.Contains(frame + 1) Then
                            Dim value1 As String
                            Dim value2 As String
                            Dim v1 As Integer
                            Dim v2 As Integer
                            value1 = ComboBox271.SelectedItem
                            value2 = ComboBox272.SelectedItem
                            If value1.Equals("X") Then
                                v1 = 10
                                v2 = 0
                            ElseIf value2.Equals("/") Then
                                v1 = CInt(value1)
                                v2 = 10 - v1
                            Else
                                v1 = CInt(value1)
                                v2 = CInt(value2)
                            End If
                            Calculate(TextBox27, TextBox26, TextBox25, 7, v1, v2, 0, 2)
                            If framevalues2(5) > 0 Then
                                TextBox26.Text = findTotal(6, 2)
                            End If
                        End If
                        If Not ((strikes2.Contains(7) Or spares2.Contains(7)) And framevalues2(6) = 0) Then
                            TextBox27.Text = findTotal(7, 2)
                        End If
                        If ComboBox281.SelectedIndex > -1 AndAlso ComboBox281.SelectedItem.Equals("X") Or ComboBox282.SelectedIndex > -1 Then
                            If Not ((strikes2.Contains(8) Or spares2.Contains(8)) And framevalues2(7) = 0) Then
                                TextBox28.Text = findTotal(8, 2)
                            End If
                            If ComboBox291.SelectedIndex > -1 AndAlso ComboBox291.SelectedItem.Equals("X") Or ComboBox292.SelectedIndex > -1 Then
                                If Not ((strikes2.Contains(9) Or spares2.Contains(9)) And framevalues2(8) = 0) Then
                                    TextBox29.Text = findTotal(9, 2)
                                End If
                                If ComboBox2103.SelectedIndex > -1 Or ComboBox2102.SelectedIndex > -1 AndAlso
                                   (Not ComboBox2101.SelectedItem.Equals("X") And Not ComboBox2102.SelectedItem.Equals("/")) Then
                                    TextBox210.Text = findTotal(10, 2)
                                End If
                            End If
                        End If
                    End If
                End If
            ElseIf frame = 6 Then
                If ComboBox271.SelectedIndex > -1 AndAlso ComboBox271.SelectedItem.Equals("X") Or ComboBox272.SelectedIndex > -1 Then
                    If strikes2.Contains(frame) Or spares2.Contains(frame) Then
                        Dim value1 As String
                        Dim value2 As String
                        Dim v1 As Integer
                        Dim v2 As Integer
                        value1 = ComboBox271.SelectedItem
                        value2 = ComboBox272.SelectedItem
                        If value1.Equals("X") Then
                            v1 = 10
                            v2 = 0
                        ElseIf value2.Equals("/") Then
                            v1 = CInt(value1)
                            v2 = 10 - v1
                        Else
                            v1 = CInt(value1)
                            v2 = CInt(value2)
                        End If
                        Calculate(TextBox27, TextBox26, TextBox25, 7, v1, v2, 0, 2)
                    End If
                    If Not ((strikes2.Contains(7) Or spares2.Contains(7)) And framevalues2(6) = 0) Then
                        TextBox27.Text = findTotal(7, 2)
                    End If
                    If ComboBox281.SelectedIndex > -1 AndAlso ComboBox281.SelectedItem.Equals("X") Or ComboBox282.SelectedIndex > -1 Then
                        If strikes2.Contains(frame) And strikes2.Contains(frame + 1) Then
                            Dim value1 As String
                            Dim value2 As String
                            Dim v1 As Integer
                            Dim v2 As Integer
                            value1 = ComboBox281.SelectedItem
                            value2 = ComboBox282.SelectedItem
                            If value1.Equals("X") Then
                                v1 = 10
                                v2 = 0
                            ElseIf value2.Equals("/") Then
                                v1 = CInt(value1)
                                v2 = 10 - v1
                            Else
                                v1 = CInt(value1)
                                v2 = CInt(value2)
                            End If
                            Calculate(TextBox28, TextBox27, TextBox26, 8, v1, v2, 0, 2)
                            If framevalues2(6) > 0 Then
                                TextBox27.Text = findTotal(7, 2)
                            End If
                        End If
                        If Not ((strikes2.Contains(8) Or spares2.Contains(8)) And framevalues2(7) = 0) Then
                            TextBox28.Text = findTotal(8, 2)
                        End If
                        If ComboBox291.SelectedIndex > -1 AndAlso ComboBox291.SelectedItem.Equals("X") Or ComboBox292.SelectedIndex > -1 Then
                            If Not ((strikes2.Contains(9) Or spares2.Contains(9)) And framevalues2(8) = 0) Then
                                TextBox29.Text = findTotal(9, 2)
                            End If
                            If ComboBox2103.SelectedIndex > -1 Or ComboBox2102.SelectedIndex > -1 AndAlso
                               (Not ComboBox2101.SelectedItem.Equals("X") And Not ComboBox2102.SelectedItem.Equals("/")) Then
                                TextBox210.Text = findTotal(10, 2)
                            End If
                        End If
                    End If
                End If
            ElseIf frame = 7 Then
                If ComboBox281.SelectedIndex > -1 AndAlso ComboBox281.SelectedItem.Equals("X") Or ComboBox282.SelectedIndex > -1 Then
                    If strikes2.Contains(frame) Or spares2.Contains(frame) Then
                        Dim value1 As String
                        Dim value2 As String
                        Dim v1 As Integer
                        Dim v2 As Integer
                        value1 = ComboBox281.SelectedItem
                        value2 = ComboBox282.SelectedItem
                        If value1.Equals("X") Then
                            v1 = 10
                            v2 = 0
                        ElseIf value2.Equals("/") Then
                            v1 = CInt(value1)
                            v2 = 10 - v1
                        Else
                            v1 = CInt(value1)
                            v2 = CInt(value2)
                        End If
                        Calculate(TextBox28, TextBox27, TextBox26, 8, v1, v2, 0, 2)
                    End If
                    If Not ((strikes2.Contains(8) Or spares2.Contains(8)) And framevalues2(7) = 0) Then
                        TextBox28.Text = findTotal(8, 2)
                    End If
                    If ComboBox291.SelectedIndex > -1 AndAlso ComboBox291.SelectedItem.Equals("X") Or ComboBox292.SelectedIndex > -1 Then
                        If strikes2.Contains(frame) And strikes2.Contains(frame + 1) Then
                            Dim value1 As String
                            Dim value2 As String
                            Dim v1 As Integer
                            Dim v2 As Integer
                            value1 = ComboBox291.SelectedItem
                            value2 = ComboBox292.SelectedItem
                            If value1.Equals("X") Then
                                v1 = 10
                                v2 = 0
                            ElseIf value2.Equals("/") Then
                                v1 = CInt(value1)
                                v2 = 10 - v1
                            Else
                                v1 = CInt(value1)
                                v2 = CInt(value2)
                            End If
                            Calculate(TextBox29, TextBox28, TextBox27, 9, v1, v2, 0, 2)
                            If framevalues2(7) > 0 Then
                                TextBox28.Text = findTotal(8, 2)
                            End If
                        End If
                        If Not ((strikes2.Contains(9) Or spares2.Contains(9)) And framevalues2(8) = 0) Then
                            TextBox29.Text = findTotal(9, 2)
                        End If
                        If ComboBox2103.SelectedIndex > -1 Or ComboBox2102.SelectedIndex > -1 AndAlso
                           (Not ComboBox2101.SelectedItem.Equals("X") And Not ComboBox2102.SelectedItem.Equals("/")) Then
                            TextBox210.Text = findTotal(10, 2)
                        End If
                    End If
                End If
            ElseIf frame = 8 Then
                If ComboBox291.SelectedIndex > -1 AndAlso ComboBox291.SelectedItem.Equals("X") Or ComboBox292.SelectedIndex > -1 Then
                    If strikes2.Contains(frame) Or spares2.Contains(frame) Then
                        Dim value1 As String
                        Dim value2 As String
                        Dim v1 As Integer
                        Dim v2 As Integer
                        value1 = ComboBox291.SelectedItem
                        value2 = ComboBox292.SelectedItem
                        If value1.Equals("X") Then
                            v1 = 10
                            v2 = 0
                        ElseIf value2.Equals("/") Then
                            v1 = CInt(value1)
                            v2 = 10 - v1
                        Else
                            v1 = CInt(value1)
                            v2 = CInt(value2)
                        End If
                        Calculate(TextBox29, TextBox28, TextBox27, 9, v1, v2, 0, 2)
                    End If
                    If Not ((strikes2.Contains(9) Or spares2.Contains(9)) And framevalues2(8) = 0) Then
                        TextBox29.Text = findTotal(9, 2)
                    End If
                    If ComboBox2103.SelectedIndex > -1 Or ComboBox2102.SelectedIndex > -1 AndAlso
                     (Not ComboBox2101.SelectedItem.Equals("X") And Not ComboBox2102.SelectedItem.Equals("/")) Then
                        If strikes2.Contains(frame) And strikes2.Contains(frame + 1) Then
                            Dim value1 As String
                            Dim value2 As String
                            Dim value3 As String
                            Dim v1 As Integer
                            Dim v2 As Integer
                            Dim v3 As Integer
                            value1 = ComboBox2101.SelectedItem
                            value2 = ComboBox2102.SelectedItem
                            value3 = ComboBox2103.SelectedItem
                            If value1.Equals("X") Then
                                v1 = 10
                            Else
                                v1 = CInt(value1)
                            End If

                            If value2.Equals("X") Then
                                v2 = 10
                            ElseIf value2.Equals("/") Then
                                v2 = 10 - v1
                            Else
                                v2 = CInt(value2)
                            End If

                            If value3.Equals("X") Then
                                v3 = 10
                            ElseIf value3.Equals("/") Then
                                v3 = 10 - v2
                            Else
                                v3 = CInt(value3)
                            End If
                            Calculate(TextBox210, TextBox29, TextBox28, 10, v1, v2, v3, 2)
                            If framevalues2(8) > 0 Then
                                TextBox29.Text = findTotal(9, 2)
                            End If
                        End If
                        TextBox210.Text = findTotal(10, 2)
                    End If
                End If
            ElseIf frame = 9 Then
                If ComboBox2103.SelectedIndex > -1 Or ComboBox2102.SelectedIndex > -1 AndAlso
                    (Not ComboBox2101.SelectedItem.Equals("X") And Not ComboBox2102.SelectedItem.Equals("/")) Then
                    If strikes2.Contains(frame) Or spares2.Contains(frame) Then
                        Dim value1 As String
                        Dim value2 As String
                        Dim value3 As String
                        Dim v1 As Integer
                        Dim v2 As Integer
                        Dim v3 As Integer
                        value1 = ComboBox2101.SelectedItem
                        value2 = ComboBox2102.SelectedItem
                        value3 = ComboBox2103.SelectedItem
                        If value1.Equals("X") Then
                            v1 = 10
                        Else
                            v1 = CInt(value1)
                        End If

                        If value2.Equals("X") Then
                            v2 = 10
                        ElseIf value2.Equals("/") Then
                            v2 = 10 - v1
                        Else
                            v2 = CInt(value2)
                        End If

                        If value3.Equals("X") Then
                            v3 = 10
                        ElseIf value3.Equals("/") Then
                            v3 = 10 - v2
                        Else
                            v3 = CInt(value3)
                        End If
                        Calculate(TextBox210, TextBox29, TextBox28, 10, v1, v2, v3, 2)
                    End If
                    TextBox210.Text = findTotal(10, 2)
                End If
            Else
                'this should never happen
            End If
        ElseIf n = 3 Then
            If frame = 1 Then
                If ComboBox321.SelectedIndex > -1 AndAlso ComboBox321.SelectedItem.Equals("X") Or ComboBox322.SelectedIndex > -1 Then
                    If strikes3.Contains(frame) Or spares3.Contains(frame) Then
                        Dim value1 As String
                        Dim value2 As String
                        Dim v1 As Integer
                        Dim v2 As Integer
                        value1 = ComboBox321.SelectedItem
                        value2 = ComboBox322.SelectedItem
                        If value1.Equals("X") Then
                            v1 = 10
                            v2 = 0
                        ElseIf value2.Equals("/") Then
                            v1 = CInt(value1)
                            v2 = 10 - v1
                        Else
                            v1 = CInt(value1)
                            v2 = CInt(value2)
                        End If
                        Calculate(TextBox32, TextBox31, TextBox31, 2, v1, v2, 0, 3)
                    End If
                    If Not ((strikes3.Contains(2) Or spares3.Contains(2)) And framevalues3(1) = 0) Then
                        TextBox32.Text = findTotal(2, 3)
                    End If
                    If ComboBox331.SelectedIndex > -1 AndAlso ComboBox331.SelectedItem.Equals("X") Or ComboBox332.SelectedIndex > -1 Then
                        If strikes3.Contains(frame) And strikes3.Contains(frame + 1) Then
                            Dim value1 As String
                            Dim value2 As String
                            Dim v1 As Integer
                            Dim v2 As Integer
                            value1 = ComboBox331.SelectedItem
                            value2 = ComboBox332.SelectedItem
                            If value1.Equals("X") Then
                                v1 = 10
                                v2 = 0
                            ElseIf value2.Equals("/") Then
                                v1 = CInt(value1)
                                v2 = 10 - v1
                            Else
                                v1 = CInt(value1)
                                v2 = CInt(value2)
                            End If
                            Calculate(TextBox33, TextBox32, TextBox31, 3, v1, v2, 0, 3)
                            If framevalues3(1) > 0 Then
                                TextBox32.Text = findTotal(2, 3)
                            End If
                        End If
                        If Not ((strikes3.Contains(3) Or spares3.Contains(3)) And framevalues3(2) = 0) Then
                            TextBox33.Text = findTotal(3, 3)
                        End If
                        If ComboBox341.SelectedIndex > -1 AndAlso ComboBox341.SelectedItem.Equals("X") Or ComboBox342.SelectedIndex > -1 Then
                            If Not ((strikes3.Contains(4) Or spares3.Contains(4)) And framevalues3(3) = 0) Then
                                TextBox34.Text = findTotal(4, 3)
                            End If
                            If ComboBox351.SelectedIndex > -1 AndAlso ComboBox351.SelectedItem.Equals("X") Or ComboBox352.SelectedIndex > -1 Then
                                If Not ((strikes3.Contains(5) Or spares3.Contains(5)) And framevalues3(4) = 0) Then
                                    TextBox35.Text = findTotal(5, 3)
                                End If
                                If ComboBox361.SelectedIndex > -1 AndAlso ComboBox361.SelectedItem.Equals("X") Or ComboBox362.SelectedIndex > -1 Then
                                    If Not ((strikes3.Contains(6) Or spares3.Contains(6)) And framevalues3(5) = 0) Then
                                        TextBox36.Text = findTotal(6, 3)
                                    End If
                                    If ComboBox371.SelectedIndex > -1 AndAlso ComboBox371.SelectedItem.Equals("X") Or ComboBox372.SelectedIndex > -1 Then
                                        If Not ((strikes3.Contains(7) Or spares3.Contains(7)) And framevalues3(6) = 0) Then
                                            TextBox37.Text = findTotal(7, 3)
                                        End If
                                        If ComboBox381.SelectedIndex > -1 AndAlso ComboBox381.SelectedItem.Equals("X") Or ComboBox382.SelectedIndex > -1 Then
                                            If Not ((strikes3.Contains(8) Or spares3.Contains(8)) And framevalues3(7) = 0) Then
                                                TextBox38.Text = findTotal(8, 3)
                                            End If
                                            If ComboBox391.SelectedIndex > -1 AndAlso ComboBox391.SelectedItem.Equals("X") Or ComboBox392.SelectedIndex > -1 Then
                                                If Not ((strikes3.Contains(9) Or spares3.Contains(9)) And framevalues3(8) = 0) Then
                                                    TextBox39.Text = findTotal(9, 3)
                                                End If
                                                If ComboBox3103.SelectedIndex > -1 Or ComboBox3102.SelectedIndex > -1 AndAlso
                                                   (Not ComboBox3101.SelectedItem.Equals("X") And Not ComboBox3102.SelectedItem.Equals("/")) Then
                                                    TextBox310.Text = findTotal(10, 3)
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            ElseIf frame = 2 Then
                If ComboBox331.SelectedIndex > -1 AndAlso ComboBox331.SelectedItem.Equals("X") Or ComboBox332.SelectedIndex > -1 Then
                    If strikes3.Contains(frame) Or spares3.Contains(frame) Then
                        Dim value1 As String
                        Dim value2 As String
                        Dim v1 As Integer
                        Dim v2 As Integer
                        value1 = ComboBox331.SelectedItem
                        value2 = ComboBox332.SelectedItem
                        If value1.Equals("X") Then
                            v1 = 10
                            v2 = 0
                        ElseIf value2.Equals("/") Then
                            v1 = CInt(value1)
                            v2 = 10 - v1
                        Else
                            v1 = CInt(value1)
                            v2 = CInt(value2)
                        End If
                        Calculate(TextBox33, TextBox32, TextBox31, 3, v1, v2, 0, 3)
                    End If
                    If Not ((strikes3.Contains(3) Or spares3.Contains(3)) And framevalues3(2) = 0) Then
                        TextBox33.Text = findTotal(3, 3)
                    End If
                    If ComboBox341.SelectedIndex > -1 AndAlso ComboBox341.SelectedItem.Equals("X") Or ComboBox342.SelectedIndex > -1 Then
                        If strikes3.Contains(frame) And strikes3.Contains(frame + 1) Then
                            Dim value1 As String
                            Dim value2 As String
                            Dim v1 As Integer
                            Dim v2 As Integer
                            value1 = ComboBox341.SelectedItem
                            value2 = ComboBox342.SelectedItem
                            If value1.Equals("X") Then
                                v1 = 10
                                v2 = 0
                            ElseIf value2.Equals("/") Then
                                v1 = CInt(value1)
                                v2 = 10 - v1
                            Else
                                v1 = CInt(value1)
                                v2 = CInt(value2)
                            End If
                            Calculate(TextBox34, TextBox33, TextBox32, 4, v1, v2, 0, 3)
                            If framevalues3(2) > 0 Then
                                TextBox33.Text = findTotal(3, 3)
                            End If
                        End If
                        If Not ((strikes3.Contains(4) Or spares3.Contains(4)) And framevalues3(3) = 0) Then
                            TextBox34.Text = findTotal(4, 3)
                        End If
                        If ComboBox351.SelectedIndex > -1 AndAlso ComboBox351.SelectedItem.Equals("X") Or ComboBox352.SelectedIndex > -1 Then
                            If Not ((strikes3.Contains(5) Or spares3.Contains(5)) And framevalues3(4) = 0) Then
                                TextBox35.Text = findTotal(5, 3)
                            End If
                            If ComboBox361.SelectedIndex > -1 AndAlso ComboBox361.SelectedItem.Equals("X") Or ComboBox362.SelectedIndex > -1 Then
                                If Not ((strikes3.Contains(6) Or spares3.Contains(6)) And framevalues3(5) = 0) Then
                                    TextBox36.Text = findTotal(6, 3)
                                End If
                                If ComboBox371.SelectedIndex > -1 AndAlso ComboBox371.SelectedItem.Equals("X") Or ComboBox372.SelectedIndex > -1 Then
                                    If Not ((strikes3.Contains(7) Or spares3.Contains(7)) And framevalues3(6) = 0) Then
                                        TextBox37.Text = findTotal(7, 3)
                                    End If
                                    If ComboBox381.SelectedIndex > -1 AndAlso ComboBox381.SelectedItem.Equals("X") Or ComboBox382.SelectedIndex > -1 Then
                                        If Not ((strikes3.Contains(8) Or spares3.Contains(8)) And framevalues3(7) = 0) Then
                                            TextBox38.Text = findTotal(8, 3)
                                        End If
                                        If ComboBox391.SelectedIndex > -1 AndAlso ComboBox391.SelectedItem.Equals("X") Or ComboBox392.SelectedIndex > -1 Then
                                            If Not ((strikes3.Contains(9) Or spares3.Contains(9)) And framevalues3(8) = 0) Then
                                                TextBox39.Text = findTotal(9, 3)
                                            End If
                                            If ComboBox3103.SelectedIndex > -1 Or ComboBox3102.SelectedIndex > -1 AndAlso
                                               (Not ComboBox3101.SelectedItem.Equals("X") And Not ComboBox3102.SelectedItem.Equals("/")) Then
                                                TextBox310.Text = findTotal(10, 3)
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            ElseIf frame = 3 Then
                If ComboBox341.SelectedIndex > -1 AndAlso ComboBox341.SelectedItem.Equals("X") Or ComboBox342.SelectedIndex > -1 Then
                    If strikes3.Contains(frame) Or spares3.Contains(frame) Then
                        Dim value1 As String
                        Dim value2 As String
                        Dim v1 As Integer
                        Dim v2 As Integer
                        value1 = ComboBox341.SelectedItem
                        value2 = ComboBox342.SelectedItem
                        If value1.Equals("X") Then
                            v1 = 10
                            v2 = 0
                        ElseIf value2.Equals("/") Then
                            v1 = CInt(value1)
                            v2 = 10 - v1
                        Else
                            v1 = CInt(value1)
                            v2 = CInt(value2)
                        End If
                        Calculate(TextBox34, TextBox33, TextBox32, 4, v1, v2, 0, 3)
                    End If
                    If Not ((strikes3.Contains(4) Or spares3.Contains(4)) And framevalues3(3) = 0) Then
                        TextBox34.Text = findTotal(4, 3)
                    End If
                    If ComboBox351.SelectedIndex > -1 AndAlso ComboBox351.SelectedItem.Equals("X") Or ComboBox352.SelectedIndex > -1 Then
                        If strikes3.Contains(frame) And strikes3.Contains(frame + 1) Then
                            Dim value1 As String
                            Dim value2 As String
                            Dim v1 As Integer
                            Dim v2 As Integer
                            value1 = ComboBox351.SelectedItem
                            value2 = ComboBox352.SelectedItem
                            If value1.Equals("X") Then
                                v1 = 10
                                v2 = 0
                            ElseIf value2.Equals("/") Then
                                v1 = CInt(value1)
                                v2 = 10 - v1
                            Else
                                v1 = CInt(value1)
                                v2 = CInt(value2)
                            End If
                            Calculate(TextBox35, TextBox34, TextBox33, 5, v1, v2, 0, 3)
                            If framevalues3(3) > 0 Then
                                TextBox34.Text = findTotal(4, 3)
                            End If
                        End If
                        If Not ((strikes3.Contains(5) Or spares3.Contains(5)) And framevalues3(4) = 0) Then
                            TextBox35.Text = findTotal(5, 3)
                        End If
                        If ComboBox361.SelectedIndex > -1 AndAlso ComboBox361.SelectedItem.Equals("X") Or ComboBox362.SelectedIndex > -1 Then
                            If Not ((strikes3.Contains(6) Or spares3.Contains(6)) And framevalues3(5) = 0) Then
                                TextBox36.Text = findTotal(6, 3)
                            End If
                            If ComboBox371.SelectedIndex > -1 AndAlso ComboBox371.SelectedItem.Equals("X") Or ComboBox372.SelectedIndex > -1 Then
                                If Not ((strikes3.Contains(7) Or spares3.Contains(7)) And framevalues3(6) = 0) Then
                                    TextBox37.Text = findTotal(7, 3)
                                End If
                                If ComboBox381.SelectedIndex > -1 AndAlso ComboBox381.SelectedItem.Equals("X") Or ComboBox382.SelectedIndex > -1 Then
                                    If Not ((strikes3.Contains(8) Or spares3.Contains(8)) And framevalues3(7) = 0) Then
                                        TextBox38.Text = findTotal(8, 3)
                                    End If
                                    If ComboBox391.SelectedIndex > -1 AndAlso ComboBox391.SelectedItem.Equals("X") Or ComboBox392.SelectedIndex > -1 Then
                                        If Not ((strikes3.Contains(9) Or spares3.Contains(9)) And framevalues3(8) = 0) Then
                                            TextBox39.Text = findTotal(9, 3)
                                        End If
                                        If ComboBox3103.SelectedIndex > -1 Or ComboBox3102.SelectedIndex > -1 AndAlso
                                           (Not ComboBox3101.SelectedItem.Equals("X") And Not ComboBox3102.SelectedItem.Equals("/")) Then
                                            TextBox310.Text = findTotal(10, 3)
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            ElseIf frame = 4 Then
                If ComboBox351.SelectedIndex > -1 AndAlso ComboBox351.SelectedItem.Equals("X") Or ComboBox352.SelectedIndex > -1 Then
                    If strikes3.Contains(frame) Or spares3.Contains(frame) Then
                        Dim value1 As String
                        Dim value2 As String
                        Dim v1 As Integer
                        Dim v2 As Integer
                        value1 = ComboBox351.SelectedItem
                        value2 = ComboBox352.SelectedItem
                        If value1.Equals("X") Then
                            v1 = 10
                            v2 = 0
                        ElseIf value2.Equals("/") Then
                            v1 = CInt(value1)
                            v2 = 10 - v1
                        Else
                            v1 = CInt(value1)
                            v2 = CInt(value2)
                        End If
                        Calculate(TextBox35, TextBox34, TextBox33, 5, v1, v2, 0, 3)
                    End If
                    If Not ((strikes3.Contains(5) Or spares3.Contains(5)) And framevalues3(4) = 0) Then
                        TextBox35.Text = findTotal(5, 3)
                    End If
                    If ComboBox361.SelectedIndex > -1 AndAlso ComboBox361.SelectedItem.Equals("X") Or ComboBox362.SelectedIndex > -1 Then
                        If strikes3.Contains(frame) And strikes3.Contains(frame + 1) Then
                            Dim value1 As String
                            Dim value2 As String
                            Dim v1 As Integer
                            Dim v2 As Integer
                            value1 = ComboBox361.SelectedItem
                            value2 = ComboBox362.SelectedItem
                            If value1.Equals("X") Then
                                v1 = 10
                                v2 = 0
                            ElseIf value2.Equals("/") Then
                                v1 = CInt(value1)
                                v2 = 10 - v1
                            Else
                                v1 = CInt(value1)
                                v2 = CInt(value2)
                            End If
                            Calculate(TextBox36, TextBox35, TextBox34, 6, v1, v2, 0, 3)
                            If framevalues3(4) > 0 Then
                                TextBox35.Text = findTotal(5, 3)
                            End If
                        End If
                        If Not ((strikes3.Contains(6) Or spares3.Contains(6)) And framevalues3(5) = 0) Then
                            TextBox36.Text = findTotal(6, 3)
                        End If
                        If ComboBox371.SelectedIndex > -1 AndAlso ComboBox371.SelectedItem.Equals("X") Or ComboBox372.SelectedIndex > -1 Then
                            If Not ((strikes3.Contains(7) Or spares3.Contains(7)) And framevalues3(6) = 0) Then
                                TextBox37.Text = findTotal(7, 3)
                            End If
                            If ComboBox381.SelectedIndex > -1 AndAlso ComboBox381.SelectedItem.Equals("X") Or ComboBox382.SelectedIndex > -1 Then
                                If Not ((strikes3.Contains(8) Or spares3.Contains(8)) And framevalues3(7) = 0) Then
                                    TextBox38.Text = findTotal(8, 3)
                                End If
                                If ComboBox391.SelectedIndex > -1 AndAlso ComboBox391.SelectedItem.Equals("X") Or ComboBox392.SelectedIndex > -1 Then
                                    If Not ((strikes3.Contains(9) Or spares3.Contains(9)) And framevalues3(8) = 0) Then
                                        TextBox39.Text = findTotal(9, 3)
                                    End If
                                    If ComboBox3103.SelectedIndex > -1 Or ComboBox3102.SelectedIndex > -1 AndAlso
                                       (Not ComboBox3101.SelectedItem.Equals("X") And Not ComboBox3102.SelectedItem.Equals("/")) Then
                                        TextBox310.Text = findTotal(10, 3)
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            ElseIf frame = 5 Then
                If ComboBox361.SelectedIndex > -1 AndAlso ComboBox361.SelectedItem.Equals("X") Or ComboBox362.SelectedIndex > -1 Then
                    If strikes3.Contains(frame) Or spares3.Contains(frame) Then
                        Dim value1 As String
                        Dim value2 As String
                        Dim v1 As Integer
                        Dim v2 As Integer
                        value1 = ComboBox361.SelectedItem
                        value2 = ComboBox362.SelectedItem
                        If value1.Equals("X") Then
                            v1 = 10
                            v2 = 0
                        ElseIf value2.Equals("/") Then
                            v1 = CInt(value1)
                            v2 = 10 - v1
                        Else
                            v1 = CInt(value1)
                            v2 = CInt(value2)
                        End If
                        Calculate(TextBox36, TextBox35, TextBox34, 6, v1, v2, 0, 3)
                    End If
                    If Not ((strikes3.Contains(6) Or spares3.Contains(6)) And framevalues3(5) = 0) Then
                        TextBox36.Text = findTotal(6, 3)
                    End If
                    If ComboBox371.SelectedIndex > -1 AndAlso ComboBox371.SelectedItem.Equals("X") Or ComboBox372.SelectedIndex > -1 Then
                        If strikes3.Contains(frame) And strikes3.Contains(frame + 1) Then
                            Dim value1 As String
                            Dim value2 As String
                            Dim v1 As Integer
                            Dim v2 As Integer
                            value1 = ComboBox371.SelectedItem
                            value2 = ComboBox372.SelectedItem
                            If value1.Equals("X") Then
                                v1 = 10
                                v2 = 0
                            ElseIf value2.Equals("/") Then
                                v1 = CInt(value1)
                                v2 = 10 - v1
                            Else
                                v1 = CInt(value1)
                                v2 = CInt(value2)
                            End If
                            Calculate(TextBox37, TextBox36, TextBox35, 7, v1, v2, 0, 3)
                            If framevalues3(5) > 0 Then
                                TextBox36.Text = findTotal(6, 3)
                            End If
                        End If
                        If Not ((strikes3.Contains(7) Or spares3.Contains(7)) And framevalues3(6) = 0) Then
                            TextBox37.Text = findTotal(7, 3)
                        End If
                        If ComboBox381.SelectedIndex > -1 AndAlso ComboBox381.SelectedItem.Equals("X") Or ComboBox382.SelectedIndex > -1 Then
                            If Not ((strikes3.Contains(8) Or spares3.Contains(8)) And framevalues3(7) = 0) Then
                                TextBox38.Text = findTotal(8, 3)
                            End If
                            If ComboBox391.SelectedIndex > -1 AndAlso ComboBox391.SelectedItem.Equals("X") Or ComboBox392.SelectedIndex > -1 Then
                                If Not ((strikes3.Contains(9) Or spares3.Contains(9)) And framevalues3(8) = 0) Then
                                    TextBox39.Text = findTotal(9, 3)
                                End If
                                If ComboBox3103.SelectedIndex > -1 Or ComboBox3102.SelectedIndex > -1 AndAlso
                                   (Not ComboBox3101.SelectedItem.Equals("X") And Not ComboBox3102.SelectedItem.Equals("/")) Then
                                    TextBox310.Text = findTotal(10, 3)
                                End If
                            End If
                        End If
                    End If
                End If
            ElseIf frame = 6 Then
                If ComboBox371.SelectedIndex > -1 AndAlso ComboBox371.SelectedItem.Equals("X") Or ComboBox372.SelectedIndex > -1 Then
                    If strikes3.Contains(frame) Or spares3.Contains(frame) Then
                        Dim value1 As String
                        Dim value2 As String
                        Dim v1 As Integer
                        Dim v2 As Integer
                        value1 = ComboBox371.SelectedItem
                        value2 = ComboBox372.SelectedItem
                        If value1.Equals("X") Then
                            v1 = 10
                            v2 = 0
                        ElseIf value2.Equals("/") Then
                            v1 = CInt(value1)
                            v2 = 10 - v1
                        Else
                            v1 = CInt(value1)
                            v2 = CInt(value2)
                        End If
                        Calculate(TextBox37, TextBox36, TextBox35, 7, v1, v2, 0, 3)
                    End If
                    If Not ((strikes3.Contains(7) Or spares3.Contains(7)) And framevalues3(6) = 0) Then
                        TextBox37.Text = findTotal(7, 3)
                    End If
                    If ComboBox381.SelectedIndex > -1 AndAlso ComboBox381.SelectedItem.Equals("X") Or ComboBox382.SelectedIndex > -1 Then
                        If strikes3.Contains(frame) And strikes3.Contains(frame + 1) Then
                            Dim value1 As String
                            Dim value2 As String
                            Dim v1 As Integer
                            Dim v2 As Integer
                            value1 = ComboBox381.SelectedItem
                            value2 = ComboBox382.SelectedItem
                            If value1.Equals("X") Then
                                v1 = 10
                                v2 = 0
                            ElseIf value2.Equals("/") Then
                                v1 = CInt(value1)
                                v2 = 10 - v1
                            Else
                                v1 = CInt(value1)
                                v2 = CInt(value2)
                            End If
                            Calculate(TextBox38, TextBox37, TextBox36, 8, v1, v2, 0, 3)
                            If framevalues3(6) > 0 Then
                                TextBox37.Text = findTotal(7, 3)
                            End If
                        End If
                        If Not ((strikes3.Contains(8) Or spares3.Contains(8)) And framevalues3(7) = 0) Then
                            TextBox38.Text = findTotal(8, 3)
                        End If
                        If ComboBox391.SelectedIndex > -1 AndAlso ComboBox391.SelectedItem.Equals("X") Or ComboBox392.SelectedIndex > -1 Then
                            If Not ((strikes3.Contains(9) Or spares3.Contains(9)) And framevalues3(8) = 0) Then
                                TextBox39.Text = findTotal(9, 3)
                            End If
                            If ComboBox3103.SelectedIndex > -1 Or ComboBox3102.SelectedIndex > -1 AndAlso
                               (Not ComboBox3101.SelectedItem.Equals("X") And Not ComboBox3102.SelectedItem.Equals("/")) Then
                                TextBox310.Text = findTotal(10, 3)
                            End If
                        End If
                    End If
                End If
            ElseIf frame = 7 Then
                If ComboBox381.SelectedIndex > -1 AndAlso ComboBox381.SelectedItem.Equals("X") Or ComboBox382.SelectedIndex > -1 Then
                    If strikes3.Contains(frame) Or spares3.Contains(frame) Then
                        Dim value1 As String
                        Dim value2 As String
                        Dim v1 As Integer
                        Dim v2 As Integer
                        value1 = ComboBox381.SelectedItem
                        value2 = ComboBox382.SelectedItem
                        If value1.Equals("X") Then
                            v1 = 10
                            v2 = 0
                        ElseIf value2.Equals("/") Then
                            v1 = CInt(value1)
                            v2 = 10 - v1
                        Else
                            v1 = CInt(value1)
                            v2 = CInt(value2)
                        End If
                        Calculate(TextBox38, TextBox37, TextBox36, 8, v1, v2, 0, 3)
                    End If
                    If Not ((strikes3.Contains(8) Or spares3.Contains(8)) And framevalues3(7) = 0) Then
                        TextBox38.Text = findTotal(8, 3)
                    End If
                    If ComboBox391.SelectedIndex > -1 AndAlso ComboBox391.SelectedItem.Equals("X") Or ComboBox392.SelectedIndex > -1 Then
                        If strikes3.Contains(frame) And strikes3.Contains(frame + 1) Then
                            Dim value1 As String
                            Dim value2 As String
                            Dim v1 As Integer
                            Dim v2 As Integer
                            value1 = ComboBox391.SelectedItem
                            value2 = ComboBox392.SelectedItem
                            If value1.Equals("X") Then
                                v1 = 10
                                v2 = 0
                            ElseIf value2.Equals("/") Then
                                v1 = CInt(value1)
                                v2 = 10 - v1
                            Else
                                v1 = CInt(value1)
                                v2 = CInt(value2)
                            End If
                            Calculate(TextBox39, TextBox38, TextBox37, 9, v1, v2, 0, 3)
                            If framevalues3(7) > 0 Then
                                TextBox38.Text = findTotal(8, 3)
                            End If
                        End If
                        If Not ((strikes3.Contains(9) Or spares3.Contains(9)) And framevalues3(8) = 0) Then
                            TextBox39.Text = findTotal(9, 3)
                        End If
                        If ComboBox3103.SelectedIndex > -1 Or ComboBox3102.SelectedIndex > -1 AndAlso
                           (Not ComboBox3101.SelectedItem.Equals("X") And Not ComboBox3102.SelectedItem.Equals("/")) Then
                            TextBox310.Text = findTotal(10, 3)
                        End If
                    End If
                End If
            ElseIf frame = 8 Then
                If ComboBox391.SelectedIndex > -1 AndAlso ComboBox391.SelectedItem.Equals("X") Or ComboBox392.SelectedIndex > -1 Then
                    If strikes3.Contains(frame) Or spares3.Contains(frame) Then
                        Dim value1 As String
                        Dim value2 As String
                        Dim v1 As Integer
                        Dim v2 As Integer
                        value1 = ComboBox391.SelectedItem
                        value2 = ComboBox392.SelectedItem
                        If value1.Equals("X") Then
                            v1 = 10
                            v2 = 0
                        ElseIf value2.Equals("/") Then
                            v1 = CInt(value1)
                            v2 = 10 - v1
                        Else
                            v1 = CInt(value1)
                            v2 = CInt(value2)
                        End If
                        Calculate(TextBox39, TextBox38, TextBox37, 9, v1, v2, 0, 3)
                    End If
                    If Not ((strikes3.Contains(9) Or spares3.Contains(9)) And framevalues3(8) = 0) Then
                        TextBox39.Text = findTotal(9, 3)
                    End If
                    If ComboBox3103.SelectedIndex > -1 Or ComboBox3102.SelectedIndex > -1 AndAlso
                     (Not ComboBox3101.SelectedItem.Equals("X") And Not ComboBox3102.SelectedItem.Equals("/")) Then
                        If strikes3.Contains(frame) And strikes3.Contains(frame + 1) Then
                            Dim value1 As String
                            Dim value2 As String
                            Dim value3 As String
                            Dim v1 As Integer
                            Dim v2 As Integer
                            Dim v3 As Integer
                            value1 = ComboBox3101.SelectedItem
                            value2 = ComboBox3102.SelectedItem
                            value3 = ComboBox3103.SelectedItem
                            If value1.Equals("X") Then
                                v1 = 10
                            Else
                                v1 = CInt(value1)
                            End If

                            If value2.Equals("X") Then
                                v2 = 10
                            ElseIf value2.Equals("/") Then
                                v2 = 10 - v1
                            Else
                                v2 = CInt(value2)
                            End If

                            If value3.Equals("X") Then
                                v3 = 10
                            ElseIf value3.Equals("/") Then
                                v3 = 10 - v2
                            Else
                                v3 = CInt(value3)
                            End If
                            Calculate(TextBox310, TextBox39, TextBox38, 10, v1, v2, v3, 3)
                            If framevalues3(8) > 0 Then
                                TextBox39.Text = findTotal(9, 3)
                            End If
                        End If
                        TextBox310.Text = findTotal(10, 3)
                    End If
                End If
            ElseIf frame = 9 Then
                If ComboBox3103.SelectedIndex > -1 Or ComboBox3102.SelectedIndex > -1 AndAlso
                    (Not ComboBox3101.SelectedItem.Equals("X") And Not ComboBox3102.SelectedItem.Equals("/")) Then
                    If strikes3.Contains(frame) Or spares3.Contains(frame) Then
                        Dim value1 As String
                        Dim value2 As String
                        Dim value3 As String
                        Dim v1 As Integer
                        Dim v2 As Integer
                        Dim v3 As Integer
                        value1 = ComboBox3101.SelectedItem
                        value2 = ComboBox3102.SelectedItem
                        value3 = ComboBox3103.SelectedItem
                        If value1.Equals("X") Then
                            v1 = 10
                        Else
                            v1 = CInt(value1)
                        End If

                        If value2.Equals("X") Then
                            v2 = 10
                        ElseIf value2.Equals("/") Then
                            v2 = 10 - v1
                        Else
                            v2 = CInt(value2)
                        End If

                        If value3.Equals("X") Then
                            v3 = 10
                        ElseIf value3.Equals("/") Then
                            v3 = 10 - v2
                        Else
                            v3 = CInt(value3)
                        End If
                        Calculate(TextBox310, TextBox39, TextBox38, 10, v1, v2, v3, 3)
                    End If
                    TextBox310.Text = findTotal(10, 3)
                End If
            Else
                'this should never happen
            End If
        ElseIf n = 4 Then
            If frame = 1 Then
                If ComboBox421.SelectedIndex > -1 AndAlso ComboBox421.SelectedItem.Equals("X") Or ComboBox422.SelectedIndex > -1 Then
                    If strikes4.Contains(frame) Or spares4.Contains(frame) Then
                        Dim value1 As String
                        Dim value2 As String
                        Dim v1 As Integer
                        Dim v2 As Integer
                        value1 = ComboBox421.SelectedItem
                        value2 = ComboBox422.SelectedItem
                        If value1.Equals("X") Then
                            v1 = 10
                            v2 = 0
                        ElseIf value2.Equals("/") Then
                            v1 = CInt(value1)
                            v2 = 10 - v1
                        Else
                            v1 = CInt(value1)
                            v2 = CInt(value2)
                        End If
                        Calculate(TextBox42, TextBox41, TextBox41, 2, v1, v2, 0, 4)
                    End If
                    If Not ((strikes4.Contains(2) Or spares4.Contains(2)) And framevalues4(1) = 0) Then
                        TextBox42.Text = findTotal(2, 4)
                    End If
                    If ComboBox431.SelectedIndex > -1 AndAlso ComboBox431.SelectedItem.Equals("X") Or ComboBox432.SelectedIndex > -1 Then
                        If strikes4.Contains(frame) And strikes4.Contains(frame + 1) Then
                            Dim value1 As String
                            Dim value2 As String
                            Dim v1 As Integer
                            Dim v2 As Integer
                            value1 = ComboBox431.SelectedItem
                            value2 = ComboBox432.SelectedItem
                            If value1.Equals("X") Then
                                v1 = 10
                                v2 = 0
                            ElseIf value2.Equals("/") Then
                                v1 = CInt(value1)
                                v2 = 10 - v1
                            Else
                                v1 = CInt(value1)
                                v2 = CInt(value2)
                            End If
                            Calculate(TextBox43, TextBox42, TextBox41, 3, v1, v2, 0, 4)
                            If framevalues4(1) > 0 Then
                                TextBox42.Text = findTotal(2, 4)
                            End If
                        End If
                        If Not ((strikes4.Contains(3) Or spares4.Contains(3)) And framevalues4(2) = 0) Then
                            TextBox43.Text = findTotal(3, 4)
                        End If
                        If ComboBox441.SelectedIndex > -1 AndAlso ComboBox441.SelectedItem.Equals("X") Or ComboBox442.SelectedIndex > -1 Then
                            If Not ((strikes4.Contains(4) Or spares4.Contains(4)) And framevalues4(3) = 0) Then
                                TextBox44.Text = findTotal(4, 4)
                            End If
                            If ComboBox451.SelectedIndex > -1 AndAlso ComboBox451.SelectedItem.Equals("X") Or ComboBox452.SelectedIndex > -1 Then
                                If Not ((strikes4.Contains(5) Or spares4.Contains(5)) And framevalues4(4) = 0) Then
                                    TextBox45.Text = findTotal(5, 4)
                                End If
                                If ComboBox461.SelectedIndex > -1 AndAlso ComboBox461.SelectedItem.Equals("X") Or ComboBox462.SelectedIndex > -1 Then
                                    If Not ((strikes4.Contains(6) Or spares4.Contains(6)) And framevalues4(5) = 0) Then
                                        TextBox46.Text = findTotal(6, 4)
                                    End If
                                    If ComboBox471.SelectedIndex > -1 AndAlso ComboBox471.SelectedItem.Equals("X") Or ComboBox472.SelectedIndex > -1 Then
                                        If Not ((strikes4.Contains(7) Or spares4.Contains(7)) And framevalues4(6) = 0) Then
                                            TextBox47.Text = findTotal(7, 4)
                                        End If
                                        If ComboBox481.SelectedIndex > -1 AndAlso ComboBox481.SelectedItem.Equals("X") Or ComboBox482.SelectedIndex > -1 Then
                                            If Not ((strikes4.Contains(8) Or spares4.Contains(8)) And framevalues4(7) = 0) Then
                                                TextBox48.Text = findTotal(8, 4)
                                            End If
                                            If ComboBox491.SelectedIndex > -1 AndAlso ComboBox491.SelectedItem.Equals("X") Or ComboBox492.SelectedIndex > -1 Then
                                                If Not ((strikes4.Contains(9) Or spares4.Contains(9)) And framevalues4(8) = 0) Then
                                                    TextBox49.Text = findTotal(9, 4)
                                                End If
                                                If ComboBox4103.SelectedIndex > -1 Or ComboBox4102.SelectedIndex > -1 AndAlso
                                                   (Not ComboBox4101.SelectedItem.Equals("X") And Not ComboBox4102.SelectedItem.Equals("/")) Then
                                                    TextBox410.Text = findTotal(10, 4)
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            ElseIf frame = 2 Then
                If ComboBox431.SelectedIndex > -1 AndAlso ComboBox431.SelectedItem.Equals("X") Or ComboBox432.SelectedIndex > -1 Then
                    If strikes4.Contains(frame) Or spares4.Contains(frame) Then
                        Dim value1 As String
                        Dim value2 As String
                        Dim v1 As Integer
                        Dim v2 As Integer
                        value1 = ComboBox431.SelectedItem
                        value2 = ComboBox432.SelectedItem
                        If value1.Equals("X") Then
                            v1 = 10
                            v2 = 0
                        ElseIf value2.Equals("/") Then
                            v1 = CInt(value1)
                            v2 = 10 - v1
                        Else
                            v1 = CInt(value1)
                            v2 = CInt(value2)
                        End If
                        Calculate(TextBox43, TextBox42, TextBox41, 3, v1, v2, 0, 4)
                    End If
                    If Not ((strikes4.Contains(3) Or spares4.Contains(3)) And framevalues4(2) = 0) Then
                        TextBox43.Text = findTotal(3, 4)
                    End If
                    If ComboBox441.SelectedIndex > -1 AndAlso ComboBox441.SelectedItem.Equals("X") Or ComboBox442.SelectedIndex > -1 Then
                        If strikes4.Contains(frame) And strikes4.Contains(frame + 1) Then
                            Dim value1 As String
                            Dim value2 As String
                            Dim v1 As Integer
                            Dim v2 As Integer
                            value1 = ComboBox441.SelectedItem
                            value2 = ComboBox442.SelectedItem
                            If value1.Equals("X") Then
                                v1 = 10
                                v2 = 0
                            ElseIf value2.Equals("/") Then
                                v1 = CInt(value1)
                                v2 = 10 - v1
                            Else
                                v1 = CInt(value1)
                                v2 = CInt(value2)
                            End If
                            Calculate(TextBox44, TextBox43, TextBox42, 4, v1, v2, 0, 4)
                            If framevalues4(2) > 0 Then
                                TextBox43.Text = findTotal(3, 4)
                            End If
                        End If
                        If Not ((strikes4.Contains(4) Or spares4.Contains(4)) And framevalues4(3) = 0) Then
                            TextBox44.Text = findTotal(4, 4)
                        End If
                        If ComboBox451.SelectedIndex > -1 AndAlso ComboBox451.SelectedItem.Equals("X") Or ComboBox452.SelectedIndex > -1 Then
                            If Not ((strikes4.Contains(5) Or spares4.Contains(5)) And framevalues4(4) = 0) Then
                                TextBox45.Text = findTotal(5, 4)
                            End If
                            If ComboBox461.SelectedIndex > -1 AndAlso ComboBox461.SelectedItem.Equals("X") Or ComboBox462.SelectedIndex > -1 Then
                                If Not ((strikes4.Contains(6) Or spares4.Contains(6)) And framevalues4(5) = 0) Then
                                    TextBox46.Text = findTotal(6, 4)
                                End If
                                If ComboBox471.SelectedIndex > -1 AndAlso ComboBox471.SelectedItem.Equals("X") Or ComboBox472.SelectedIndex > -1 Then
                                    If Not ((strikes4.Contains(7) Or spares4.Contains(7)) And framevalues4(6) = 0) Then
                                        TextBox47.Text = findTotal(7, 4)
                                    End If
                                    If ComboBox481.SelectedIndex > -1 AndAlso ComboBox481.SelectedItem.Equals("X") Or ComboBox482.SelectedIndex > -1 Then
                                        If Not ((strikes4.Contains(8) Or spares4.Contains(8)) And framevalues4(7) = 0) Then
                                            TextBox48.Text = findTotal(8, 4)
                                        End If
                                        If ComboBox491.SelectedIndex > -1 AndAlso ComboBox491.SelectedItem.Equals("X") Or ComboBox492.SelectedIndex > -1 Then
                                            If Not ((strikes4.Contains(9) Or spares4.Contains(9)) And framevalues4(8) = 0) Then
                                                TextBox49.Text = findTotal(9, 4)
                                            End If
                                            If ComboBox4103.SelectedIndex > -1 Or ComboBox4102.SelectedIndex > -1 AndAlso
                                               (Not ComboBox4101.SelectedItem.Equals("X") And Not ComboBox4102.SelectedItem.Equals("/")) Then
                                                TextBox410.Text = findTotal(10, 4)
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            ElseIf frame = 3 Then
                If ComboBox441.SelectedIndex > -1 AndAlso ComboBox441.SelectedItem.Equals("X") Or ComboBox442.SelectedIndex > -1 Then
                    If strikes4.Contains(frame) Or spares4.Contains(frame) Then
                        Dim value1 As String
                        Dim value2 As String
                        Dim v1 As Integer
                        Dim v2 As Integer
                        value1 = ComboBox441.SelectedItem
                        value2 = ComboBox442.SelectedItem
                        If value1.Equals("X") Then
                            v1 = 10
                            v2 = 0
                        ElseIf value2.Equals("/") Then
                            v1 = CInt(value1)
                            v2 = 10 - v1
                        Else
                            v1 = CInt(value1)
                            v2 = CInt(value2)
                        End If
                        Calculate(TextBox44, TextBox43, TextBox42, 4, v1, v2, 0, 4)
                    End If
                    If Not ((strikes4.Contains(4) Or spares4.Contains(4)) And framevalues4(3) = 0) Then
                        TextBox44.Text = findTotal(4, 4)
                    End If
                    If ComboBox451.SelectedIndex > -1 AndAlso ComboBox451.SelectedItem.Equals("X") Or ComboBox452.SelectedIndex > -1 Then
                        If strikes4.Contains(frame) And strikes4.Contains(frame + 1) Then
                            Dim value1 As String
                            Dim value2 As String
                            Dim v1 As Integer
                            Dim v2 As Integer
                            value1 = ComboBox451.SelectedItem
                            value2 = ComboBox452.SelectedItem
                            If value1.Equals("X") Then
                                v1 = 10
                                v2 = 0
                            ElseIf value2.Equals("/") Then
                                v1 = CInt(value1)
                                v2 = 10 - v1
                            Else
                                v1 = CInt(value1)
                                v2 = CInt(value2)
                            End If
                            Calculate(TextBox45, TextBox44, TextBox43, 5, v1, v2, 0, 4)
                            If framevalues4(3) > 0 Then
                                TextBox44.Text = findTotal(4, 4)
                            End If
                        End If
                        If Not ((strikes4.Contains(5) Or spares4.Contains(5)) And framevalues4(4) = 0) Then
                            TextBox45.Text = findTotal(5, 4)
                        End If
                        If ComboBox461.SelectedIndex > -1 AndAlso ComboBox461.SelectedItem.Equals("X") Or ComboBox462.SelectedIndex > -1 Then
                            If Not ((strikes4.Contains(6) Or spares4.Contains(6)) And framevalues4(5) = 0) Then
                                TextBox46.Text = findTotal(6, 4)
                            End If
                            If ComboBox471.SelectedIndex > -1 AndAlso ComboBox471.SelectedItem.Equals("X") Or ComboBox472.SelectedIndex > -1 Then
                                If Not ((strikes4.Contains(7) Or spares4.Contains(7)) And framevalues4(6) = 0) Then
                                    TextBox47.Text = findTotal(7, 4)
                                End If
                                If ComboBox481.SelectedIndex > -1 AndAlso ComboBox481.SelectedItem.Equals("X") Or ComboBox482.SelectedIndex > -1 Then
                                    If Not ((strikes4.Contains(8) Or spares4.Contains(8)) And framevalues4(7) = 0) Then
                                        TextBox48.Text = findTotal(8, 4)
                                    End If
                                    If ComboBox491.SelectedIndex > -1 AndAlso ComboBox491.SelectedItem.Equals("X") Or ComboBox492.SelectedIndex > -1 Then
                                        If Not ((strikes4.Contains(9) Or spares4.Contains(9)) And framevalues4(8) = 0) Then
                                            TextBox49.Text = findTotal(9, 4)
                                        End If
                                        If ComboBox4103.SelectedIndex > -1 Or ComboBox4102.SelectedIndex > -1 AndAlso
                                           (Not ComboBox4101.SelectedItem.Equals("X") And Not ComboBox4102.SelectedItem.Equals("/")) Then
                                            TextBox410.Text = findTotal(10, 4)
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            ElseIf frame = 4 Then
                If ComboBox451.SelectedIndex > -1 AndAlso ComboBox451.SelectedItem.Equals("X") Or ComboBox452.SelectedIndex > -1 Then
                    If strikes4.Contains(frame) Or spares4.Contains(frame) Then
                        Dim value1 As String
                        Dim value2 As String
                        Dim v1 As Integer
                        Dim v2 As Integer
                        value1 = ComboBox451.SelectedItem
                        value2 = ComboBox452.SelectedItem
                        If value1.Equals("X") Then
                            v1 = 10
                            v2 = 0
                        ElseIf value2.Equals("/") Then
                            v1 = CInt(value1)
                            v2 = 10 - v1
                        Else
                            v1 = CInt(value1)
                            v2 = CInt(value2)
                        End If
                        Calculate(TextBox45, TextBox44, TextBox43, 5, v1, v2, 0, 4)
                    End If
                    If Not ((strikes4.Contains(5) Or spares4.Contains(5)) And framevalues4(4) = 0) Then
                        TextBox45.Text = findTotal(5, 4)
                    End If
                    If ComboBox461.SelectedIndex > -1 AndAlso ComboBox461.SelectedItem.Equals("X") Or ComboBox462.SelectedIndex > -1 Then
                        If strikes4.Contains(frame) And strikes4.Contains(frame + 1) Then
                            Dim value1 As String
                            Dim value2 As String
                            Dim v1 As Integer
                            Dim v2 As Integer
                            value1 = ComboBox461.SelectedItem
                            value2 = ComboBox462.SelectedItem
                            If value1.Equals("X") Then
                                v1 = 10
                                v2 = 0
                            ElseIf value2.Equals("/") Then
                                v1 = CInt(value1)
                                v2 = 10 - v1
                            Else
                                v1 = CInt(value1)
                                v2 = CInt(value2)
                            End If
                            Calculate(TextBox46, TextBox45, TextBox44, 6, v1, v2, 0, 4)
                            If framevalues4(4) > 0 Then
                                TextBox45.Text = findTotal(5, 4)
                            End If
                        End If
                        If Not ((strikes4.Contains(6) Or spares4.Contains(6)) And framevalues4(5) = 0) Then
                            TextBox46.Text = findTotal(6, 4)
                        End If
                        If ComboBox471.SelectedIndex > -1 AndAlso ComboBox471.SelectedItem.Equals("X") Or ComboBox472.SelectedIndex > -1 Then
                            If Not ((strikes4.Contains(7) Or spares4.Contains(7)) And framevalues4(6) = 0) Then
                                TextBox47.Text = findTotal(7, 4)
                            End If
                            If ComboBox481.SelectedIndex > -1 AndAlso ComboBox481.SelectedItem.Equals("X") Or ComboBox482.SelectedIndex > -1 Then
                                If Not ((strikes4.Contains(8) Or spares4.Contains(8)) And framevalues4(7) = 0) Then
                                    TextBox48.Text = findTotal(8, 4)
                                End If
                                If ComboBox491.SelectedIndex > -1 AndAlso ComboBox491.SelectedItem.Equals("X") Or ComboBox492.SelectedIndex > -1 Then
                                    If Not ((strikes4.Contains(9) Or spares4.Contains(9)) And framevalues4(8) = 0) Then
                                        TextBox49.Text = findTotal(9, 4)
                                    End If
                                    If ComboBox4103.SelectedIndex > -1 Or ComboBox4102.SelectedIndex > -1 AndAlso
                                       (Not ComboBox4101.SelectedItem.Equals("X") And Not ComboBox4102.SelectedItem.Equals("/")) Then
                                        TextBox410.Text = findTotal(10, 4)
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            ElseIf frame = 5 Then
                If ComboBox461.SelectedIndex > -1 AndAlso ComboBox461.SelectedItem.Equals("X") Or ComboBox462.SelectedIndex > -1 Then
                    If strikes1.Contains(frame) Or spares4.Contains(frame) Then
                        Dim value1 As String
                        Dim value2 As String
                        Dim v1 As Integer
                        Dim v2 As Integer
                        value1 = ComboBox461.SelectedItem
                        value2 = ComboBox462.SelectedItem
                        If value1.Equals("X") Then
                            v1 = 10
                            v2 = 0
                        ElseIf value2.Equals("/") Then
                            v1 = CInt(value1)
                            v2 = 10 - v1
                        Else
                            v1 = CInt(value1)
                            v2 = CInt(value2)
                        End If
                        Calculate(TextBox46, TextBox45, TextBox44, 6, v1, v2, 0, 4)
                    End If
                    If Not ((strikes4.Contains(6) Or spares4.Contains(6)) And framevalues4(5) = 0) Then
                        TextBox46.Text = findTotal(6, 4)
                    End If
                    If ComboBox471.SelectedIndex > -1 AndAlso ComboBox471.SelectedItem.Equals("X") Or ComboBox472.SelectedIndex > -1 Then
                        If strikes4.Contains(frame) And strikes4.Contains(frame + 1) Then
                            Dim value1 As String
                            Dim value2 As String
                            Dim v1 As Integer
                            Dim v2 As Integer
                            value1 = ComboBox471.SelectedItem
                            value2 = ComboBox472.SelectedItem
                            If value1.Equals("X") Then
                                v1 = 10
                                v2 = 0
                            ElseIf value2.Equals("/") Then
                                v1 = CInt(value1)
                                v2 = 10 - v1
                            Else
                                v1 = CInt(value1)
                                v2 = CInt(value2)
                            End If
                            Calculate(TextBox47, TextBox46, TextBox45, 7, v1, v2, 0, 4)
                            If framevalues4(5) > 0 Then
                                TextBox46.Text = findTotal(6, 4)
                            End If
                        End If
                        If Not ((strikes4.Contains(7) Or spares4.Contains(7)) And framevalues4(6) = 0) Then
                            TextBox47.Text = findTotal(7, 4)
                        End If
                        If ComboBox491.SelectedIndex > -1 AndAlso ComboBox491.SelectedItem.Equals("X") Or ComboBox492.SelectedIndex > -1 Then
                            If Not ((strikes4.Contains(9) Or spares4.Contains(9)) And framevalues4(8) = 0) Then
                                TextBox49.Text = findTotal(9, 4)
                            End If
                            If ComboBox4103.SelectedIndex > -1 Or ComboBox4102.SelectedIndex > -1 AndAlso
                               (Not ComboBox4101.SelectedItem.Equals("X") And Not ComboBox4102.SelectedItem.Equals("/")) Then
                                TextBox410.Text = findTotal(10, 4)
                            End If
                        End If
                    End If
                End If
            End If
        ElseIf frame = 6 Then
            If ComboBox471.SelectedIndex > -1 AndAlso ComboBox471.SelectedItem.Equals("X") Or ComboBox472.SelectedIndex > -1 Then
                If strikes4.Contains(frame) Or spares4.Contains(frame) Then
                    Dim value1 As String
                    Dim value2 As String
                    Dim v1 As Integer
                    Dim v2 As Integer
                    value1 = ComboBox471.SelectedItem
                    value2 = ComboBox472.SelectedItem
                    If value1.Equals("X") Then
                        v1 = 10
                        v2 = 0
                    ElseIf value2.Equals("/") Then
                        v1 = CInt(value1)
                        v2 = 10 - v1
                    Else
                        v1 = CInt(value1)
                        v2 = CInt(value2)
                    End If
                    Calculate(TextBox47, TextBox46, TextBox45, 7, v1, v2, 0, 4)
                End If
                If Not ((strikes4.Contains(7) Or spares4.Contains(7)) And framevalues4(6) = 0) Then
                    TextBox47.Text = findTotal(7, 4)
                End If
                If ComboBox481.SelectedIndex > -1 AndAlso ComboBox481.SelectedItem.Equals("X") Or ComboBox482.SelectedIndex > -1 Then
                    If strikes4.Contains(frame) And strikes4.Contains(frame + 1) Then
                        Dim value1 As String
                        Dim value2 As String
                        Dim v1 As Integer
                        Dim v2 As Integer
                        value1 = ComboBox481.SelectedItem
                        value2 = ComboBox482.SelectedItem
                        If value1.Equals("X") Then
                            v1 = 10
                            v2 = 0
                        ElseIf value2.Equals("/") Then
                            v1 = CInt(value1)
                            v2 = 10 - v1
                        Else
                            v1 = CInt(value1)
                            v2 = CInt(value2)
                        End If
                        Calculate(TextBox48, TextBox47, TextBox46, 8, v1, v2, 0, 4)
                        If framevalues4(6) > 0 Then
                            TextBox47.Text = findTotal(7, 4)
                        End If
                    End If
                    If Not ((strikes4.Contains(8) Or spares4.Contains(8)) And framevalues4(7) = 0) Then
                        TextBox48.Text = findTotal(8, 4)
                    End If
                    If ComboBox491.SelectedIndex > -1 AndAlso ComboBox491.SelectedItem.Equals("X") Or ComboBox492.SelectedIndex > -1 Then
                        If Not ((strikes4.Contains(9) Or spares4.Contains(9)) And framevalues4(8) = 0) Then
                            TextBox49.Text = findTotal(9, 4)
                        End If
                        If ComboBox4103.SelectedIndex > -1 Or ComboBox4102.SelectedIndex > -1 AndAlso
                           (Not ComboBox4101.SelectedItem.Equals("X") And Not ComboBox4102.SelectedItem.Equals("/")) Then
                            TextBox410.Text = findTotal(10, 4)
                        End If
                    End If
                End If
            End If
        ElseIf frame = 7 Then
            If ComboBox481.SelectedIndex > -1 AndAlso ComboBox481.SelectedItem.Equals("X") Or ComboBox482.SelectedIndex > -1 Then
                If strikes1.Contains(frame) Or spares4.Contains(frame) Then
                    Dim value1 As String
                    Dim value2 As String
                    Dim v1 As Integer
                    Dim v2 As Integer
                    value1 = ComboBox481.SelectedItem
                    value2 = ComboBox482.SelectedItem
                    If value1.Equals("X") Then
                        v1 = 10
                        v2 = 0
                    ElseIf value2.Equals("/") Then
                        v1 = CInt(value1)
                        v2 = 10 - v1
                    Else
                        v1 = CInt(value1)
                        v2 = CInt(value2)
                    End If
                    Calculate(TextBox48, TextBox47, TextBox46, 8, v1, v2, 0, 4)
                End If
                If Not ((strikes4.Contains(8) Or spares4.Contains(8)) And framevalues4(7) = 0) Then
                    TextBox48.Text = findTotal(8, 4)
                End If
                If ComboBox491.SelectedIndex > -1 AndAlso ComboBox491.SelectedItem.Equals("X") Or ComboBox492.SelectedIndex > -1 Then
                    If strikes4.Contains(frame) And strikes4.Contains(frame + 1) Then
                        Dim value1 As String
                        Dim value2 As String
                        Dim v1 As Integer
                        Dim v2 As Integer
                        value1 = ComboBox491.SelectedItem
                        value2 = ComboBox492.SelectedItem
                        If value1.Equals("X") Then
                            v1 = 10
                            v2 = 0
                        ElseIf value2.Equals("/") Then
                            v1 = CInt(value1)
                            v2 = 10 - v1
                        Else
                            v1 = CInt(value1)
                            v2 = CInt(value2)
                        End If
                        Calculate(TextBox49, TextBox48, TextBox47, 9, v1, v2, 0, 4)
                        If framevalues4(7) > 0 Then
                            TextBox48.Text = findTotal(8, 4)
                        End If
                    End If
                    If Not ((strikes4.Contains(9) Or spares4.Contains(9)) And framevalues4(8) = 0) Then
                        TextBox49.Text = findTotal(9, 4)
                    End If
                    If ComboBox4103.SelectedIndex > -1 Or ComboBox4102.SelectedIndex > -1 AndAlso
                      (Not ComboBox4101.SelectedItem.Equals("X") And Not ComboBox4102.SelectedItem.Equals("/")) Then
                        TextBox410.Text = findTotal(10, 4)
                    End If
                End If
            End If
        ElseIf frame = 8 Then
            If ComboBox491.SelectedIndex > -1 AndAlso ComboBox491.SelectedItem.Equals("X") Or ComboBox492.SelectedIndex > -1 Then
                If strikes4.Contains(frame) Or spares4.Contains(frame) Then
                    Dim value1 As String
                    Dim value2 As String
                    Dim v1 As Integer
                    Dim v2 As Integer
                    value1 = ComboBox491.SelectedItem
                    value2 = ComboBox492.SelectedItem
                    If value1.Equals("X") Then
                        v1 = 10
                        v2 = 0
                    ElseIf value2.Equals("/") Then
                        v1 = CInt(value1)
                        v2 = 10 - v1
                    Else
                        v1 = CInt(value1)
                        v2 = CInt(value2)
                    End If
                    Calculate(TextBox49, TextBox48, TextBox47, 9, v1, v2, 0, 4)
                End If
                If Not ((strikes4.Contains(9) Or spares4.Contains(9)) And framevalues4(8) = 0) Then
                    TextBox49.Text = findTotal(9, 4)
                End If
                If ComboBox4103.SelectedIndex > -1 Or ComboBox4102.SelectedIndex > -1 AndAlso
                 (Not ComboBox4101.SelectedItem.Equals("X") And Not ComboBox4102.SelectedItem.Equals("/")) Then
                    If strikes4.Contains(frame) And strikes4.Contains(frame + 1) Then
                        Dim value1 As String
                        Dim value2 As String
                        Dim value3 As String
                        Dim v1 As Integer
                        Dim v2 As Integer
                        Dim v3 As Integer
                        value1 = ComboBox4101.SelectedItem
                        value2 = ComboBox4102.SelectedItem
                        value3 = ComboBox4103.SelectedItem
                        If value1.Equals("X") Then
                            v1 = 10
                        Else
                            v1 = CInt(value1)
                        End If

                        If value2.Equals("X") Then
                            v2 = 10
                        ElseIf value2.Equals("/") Then
                            v2 = 10 - v1
                        Else
                            v2 = CInt(value2)
                        End If

                        If value3.Equals("X") Then
                            v3 = 10
                        ElseIf value3.Equals("/") Then
                            v3 = 10 - v2
                        Else
                            v3 = CInt(value3)
                        End If
                        Calculate(TextBox410, TextBox49, TextBox48, 10, v1, v2, v3, 4)
                        If framevalues4(8) > 0 Then
                            TextBox49.Text = findTotal(9, 4)
                        End If
                    End If
                    TextBox410.Text = findTotal(10, 4)
                End If
            End If
        ElseIf frame = 9 Then
            If ComboBox4103.SelectedIndex > -1 Or ComboBox4102.SelectedIndex > -1 AndAlso
                (Not ComboBox4101.SelectedItem.Equals("X") And Not ComboBox4102.SelectedItem.Equals("/")) Then
                If strikes4.Contains(frame) Or spares4.Contains(frame) Then
                    Dim value1 As String
                    Dim value2 As String
                    Dim value3 As String
                    Dim v1 As Integer
                    Dim v2 As Integer
                    Dim v3 As Integer
                    value1 = ComboBox4101.SelectedItem
                    value2 = ComboBox4102.SelectedItem
                    value3 = ComboBox4103.SelectedItem
                    If value1.Equals("X") Then
                        v1 = 10
                    Else
                        v1 = CInt(value1)
                    End If

                    If value2.Equals("X") Then
                        v2 = 10
                    ElseIf value2.Equals("/") Then
                        v2 = 10 - v1
                    Else
                        v2 = CInt(value2)
                    End If

                    If value3.Equals("X") Then
                        v3 = 10
                    ElseIf value3.Equals("/") Then
                        v3 = 10 - v2
                    Else
                        v3 = CInt(value3)
                    End If
                    Calculate(TextBox410, TextBox49, TextBox48, 10, v1, v2, v3, 4)
                End If
                TextBox410.Text = findTotal(10, 4)
            End If
        Else
            'this should never happen
        End If
    End Sub

    'This chunk starts the event handlers. Each combobox has a selected index changed event that calls the 
    'calculate method with the corresponding information. These events also handle dynamic modifications
    'to the possible values in the comboboxes, such as if you get a strike on the first shot, you can't enter
    'anything in the second shot, or if you get 3 pins down in the first shot, then the only possible values 
    'in the second shot are 0-5 and /. They each also enable the next combobox so that more values can be added
    'in the correct order.
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox111.SelectedIndexChanged
        Dim value As String
        value = ComboBox111.SelectedItem
        If Not String.IsNullOrEmpty(value) Then
            If value.Equals("X") Then
                Calculate(TextBox11, TextBox11, TextBox11, 1, 10, 0, 0, 1)
                ComboBox112.Items.Clear()
                ComboBox112.Enabled = False
                ComboBox121.Enabled = True
            Else
                ComboBox112.Items.Clear()
                For i As Integer = 0 To (9 - value) Step 1
                    ComboBox112.Items.Add(i)
                Next
                ComboBox112.Items.Add("/")
                ComboBox112.Enabled = True
            End If
        End If
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox112.SelectedIndexChanged
        Dim v1 As Integer
        Dim value2 As String
        Dim v2 As Integer
        v1 = ComboBox111.SelectedItem
        value2 = ComboBox112.SelectedItem
        If Not String.IsNullOrEmpty(value2) And Not String.IsNullOrEmpty(v1) Then
            If value2.Equals("/") Then
                v2 = 10 - v1
            Else
                v2 = CInt(value2)
            End If
            Calculate(TextBox11, TextBox11, TextBox11, 1, v1, v2, 0, 1)
            ComboBox121.Enabled = True
        End If
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox121.SelectedIndexChanged
        Dim value As String
        value = ComboBox121.SelectedItem
        If Not String.IsNullOrEmpty(value) Then
            If value.Equals("X") Then
                Calculate(TextBox12, TextBox11, TextBox11, 2, 10, 0, 0, 1)
                ComboBox122.Items.Clear()
                ComboBox122.Enabled = False
                ComboBox131.Enabled = True
            Else
                ComboBox122.Items.Clear()
                For i As Integer = 0 To (9 - value) Step 1
                    ComboBox122.Items.Add(i)
                Next
                ComboBox122.Items.Add("/")
                ComboBox122.Enabled = True
            End If
        End If
    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox122.SelectedIndexChanged
        Dim v1 As Integer
        Dim value2 As String
        Dim v2 As Integer
        v1 = ComboBox121.SelectedItem
        value2 = ComboBox122.SelectedItem
        If Not String.IsNullOrEmpty(value2) And Not String.IsNullOrEmpty(v1) Then
            If value2.Equals("/") Then
                v2 = 10 - v1
            Else
                v2 = CInt(value2)
            End If
            Calculate(TextBox12, TextBox11, TextBox11, 2, v1, v2, 0, 1)
            ComboBox131.Enabled = True
        End If
    End Sub

    Private Sub ComboBox131_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox131.SelectedIndexChanged
        Dim value As String
        value = ComboBox131.SelectedItem
        If Not String.IsNullOrEmpty(value) Then
            If value.Equals("X") Then
                Calculate(TextBox13, TextBox12, TextBox11, 3, 10, 0, 0, 1)
                ComboBox132.Items.Clear()
                ComboBox132.Enabled = False
                ComboBox141.Enabled = True
            Else
                ComboBox132.Items.Clear()
                For i As Integer = 0 To (9 - value) Step 1
                    ComboBox132.Items.Add(i)
                Next
                ComboBox132.Items.Add("/")
                ComboBox132.Enabled = True
            End If
        End If
    End Sub

    Private Sub ComboBox132_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox132.SelectedIndexChanged
        Dim v1 As Integer
        Dim value2 As String
        Dim v2 As Integer
        v1 = ComboBox131.SelectedItem
        value2 = ComboBox132.SelectedItem
        If Not String.IsNullOrEmpty(value2) And Not String.IsNullOrEmpty(v1) Then
            If value2.Equals("/") Then
                v2 = 10 - v1
            Else
                v2 = CInt(value2)
            End If
            Calculate(TextBox13, TextBox12, TextBox11, 3, v1, v2, 0, 1)
            ComboBox141.Enabled = True
        End If
    End Sub

    Private Sub ComboBox141_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox141.SelectedIndexChanged
        Dim value As String
        value = ComboBox141.SelectedItem
        If Not String.IsNullOrEmpty(value) Then
            If value.Equals("X") Then
                Calculate(TextBox14, TextBox13, TextBox12, 4, 10, 0, 0, 1)
                ComboBox142.Items.Clear()
                ComboBox142.Enabled = False
                ComboBox151.Enabled = True
            Else
                ComboBox142.Items.Clear()
                For i As Integer = 0 To (9 - value) Step 1
                    ComboBox142.Items.Add(i)
                Next
                ComboBox142.Items.Add("/")
                ComboBox142.Enabled = True
            End If
        End If
    End Sub

    Private Sub ComboBox142_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox142.SelectedIndexChanged
        Dim v1 As Integer
        Dim value2 As String
        Dim v2 As Integer
        v1 = ComboBox141.SelectedItem
        value2 = ComboBox142.SelectedItem
        If Not String.IsNullOrEmpty(value2) And Not String.IsNullOrEmpty(v1) Then
            If value2.Equals("/") Then
                v2 = 10 - v1
            Else
                v2 = CInt(value2)
            End If
            Calculate(TextBox14, TextBox13, TextBox12, 4, v1, v2, 0, 1)
            ComboBox151.Enabled = True
        End If
    End Sub

    Private Sub ComboBox151_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox151.SelectedIndexChanged
        Dim value As String
        value = ComboBox151.SelectedItem
        If Not String.IsNullOrEmpty(value) Then
            If value.Equals("X") Then
                Calculate(TextBox15, TextBox14, TextBox13, 5, 10, 0, 0, 1)
                ComboBox152.Items.Clear()
                ComboBox152.Enabled = False
                ComboBox161.Enabled = True
            Else
                ComboBox152.Items.Clear()
                For i As Integer = 0 To (9 - value) Step 1
                    ComboBox152.Items.Add(i)
                Next
                ComboBox152.Items.Add("/")
                ComboBox152.Enabled = True
            End If
        End If
    End Sub

    Private Sub ComboBox152_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox152.SelectedIndexChanged
        Dim v1 As Integer
        Dim value2 As String
        Dim v2 As Integer
        v1 = ComboBox151.SelectedItem
        value2 = ComboBox152.SelectedItem
        If Not String.IsNullOrEmpty(value2) And Not String.IsNullOrEmpty(v1) Then
            If value2.Equals("/") Then
                v2 = 10 - v1
            Else
                v2 = CInt(value2)
            End If
            Calculate(TextBox15, TextBox14, TextBox13, 5, v1, v2, 0, 1)
            ComboBox161.Enabled = True
        End If
    End Sub

    Private Sub ComboBox161_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox161.SelectedIndexChanged
        Dim value As String
        value = ComboBox161.SelectedItem
        If Not String.IsNullOrEmpty(value) Then
            If value.Equals("X") Then
                Calculate(TextBox16, TextBox15, TextBox14, 6, 10, 0, 0, 1)
                ComboBox162.Items.Clear()
                ComboBox162.Enabled = False
                ComboBox171.Enabled = True
            Else
                ComboBox162.Items.Clear()
                For i As Integer = 0 To (9 - value) Step 1
                    ComboBox162.Items.Add(i)
                Next
                ComboBox162.Items.Add("/")
                ComboBox162.Enabled = True
            End If
        End If
    End Sub

    Private Sub ComboBox162_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox162.SelectedIndexChanged
        Dim v1 As Integer
        Dim value2 As String
        Dim v2 As Integer
        v1 = ComboBox161.SelectedItem
        value2 = ComboBox162.SelectedItem
        If Not String.IsNullOrEmpty(value2) And Not String.IsNullOrEmpty(v1) Then
            If value2.Equals("/") Then
                v2 = 10 - v1
            Else
                v2 = CInt(value2)
            End If
            Calculate(TextBox16, TextBox15, TextBox14, 6, v1, v2, 0, 1)
            ComboBox171.Enabled = True
        End If
    End Sub

    Private Sub ComboBox171_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox171.SelectedIndexChanged
        Dim value As String
        value = ComboBox171.SelectedItem
        If Not String.IsNullOrEmpty(value) Then
            If value.Equals("X") Then
                Calculate(TextBox17, TextBox16, TextBox15, 7, 10, 0, 0, 1)
                ComboBox172.Items.Clear()
                ComboBox172.Enabled = False
                ComboBox181.Enabled = True
            Else
                ComboBox172.Items.Clear()
                For i As Integer = 0 To (9 - value) Step 1
                    ComboBox172.Items.Add(i)
                Next
                ComboBox172.Items.Add("/")
                ComboBox172.Enabled = True
            End If
        End If
    End Sub

    Private Sub ComboBox172_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox172.SelectedIndexChanged
        Dim v1 As Integer
        Dim value2 As String
        Dim v2 As Integer
        v1 = ComboBox171.SelectedItem
        value2 = ComboBox172.SelectedItem
        If Not String.IsNullOrEmpty(value2) And Not String.IsNullOrEmpty(v1) Then
            If value2.Equals("/") Then
                v2 = 10 - v1
            Else
                v2 = CInt(value2)
            End If
            Calculate(TextBox17, TextBox16, TextBox15, 7, v1, v2, 0, 1)
            ComboBox181.Enabled = True
        End If
    End Sub

    Private Sub ComboBox181_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox181.SelectedIndexChanged
        Dim value As String
        value = ComboBox181.SelectedItem
        If Not String.IsNullOrEmpty(value) Then
            If value.Equals("X") Then
                Calculate(TextBox18, TextBox17, TextBox16, 8, 10, 0, 0, 1)
                ComboBox182.Items.Clear()
                ComboBox182.Enabled = False
                ComboBox191.Enabled = True
            Else
                ComboBox182.Items.Clear()
                For i As Integer = 0 To (9 - value) Step 1
                    ComboBox182.Items.Add(i)
                Next
                ComboBox182.Items.Add("/")
                ComboBox182.Enabled = True
            End If
        End If
    End Sub

    Private Sub ComboBox182_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox182.SelectedIndexChanged
        Dim v1 As Integer
        Dim value2 As String
        Dim v2 As Integer
        v1 = ComboBox181.SelectedItem
        value2 = ComboBox182.SelectedItem
        If Not String.IsNullOrEmpty(value2) And Not String.IsNullOrEmpty(v1) Then
            If value2.Equals("/") Then
                v2 = 10 - v1
            Else
                v2 = CInt(value2)
            End If
            Calculate(TextBox18, TextBox17, TextBox16, 8, v1, v2, 0, 1)
            ComboBox191.Enabled = True
        End If
    End Sub

    Private Sub ComboBox191_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox191.SelectedIndexChanged
        Dim value As String
        value = ComboBox191.SelectedItem
        If Not String.IsNullOrEmpty(value) Then
            If value.Equals("X") Then
                Calculate(TextBox19, TextBox18, TextBox17, 9, 10, 0, 0, 1)
                ComboBox192.Items.Clear()
                ComboBox192.Enabled = False
                ComboBox1101.Enabled = True
            Else
                ComboBox192.Items.Clear()
                For i As Integer = 0 To (9 - value) Step 1
                    ComboBox192.Items.Add(i)
                Next
                ComboBox192.Items.Add("/")
                ComboBox192.Enabled = True
            End If
        End If
    End Sub

    Private Sub ComboBox192_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox192.SelectedIndexChanged
        Dim v1 As Integer
        Dim value2 As String
        Dim v2 As Integer
        v1 = ComboBox191.SelectedItem
        value2 = ComboBox192.SelectedItem
        If Not String.IsNullOrEmpty(value2) And Not String.IsNullOrEmpty(v1) Then
            If value2.Equals("/") Then
                v2 = 10 - v1
            Else
                v2 = CInt(value2)
            End If
            Calculate(TextBox19, TextBox18, TextBox17, 9, v1, v2, 0, 1)
            ComboBox1101.Enabled = True
        End If
    End Sub

    Private Sub ComboBox1101_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1101.SelectedIndexChanged
        Dim value As String
        value = ComboBox1101.SelectedItem
        If Not String.IsNullOrEmpty(value) Then
            If value.Equals("X") Then
                ComboBox1102.Items.Clear()
                For i As Integer = 0 To 9 Step 1
                    ComboBox1102.Items.Add(i)
                Next
                ComboBox1102.Items.Add("X")
                ComboBox1102.Enabled = True
                ComboBox1103.Items.Clear()
                TextBox110.Text = ""
            Else
                ComboBox1102.Items.Clear()
                For i As Integer = 0 To (9 - value) Step 1
                    ComboBox1102.Items.Add(i)
                Next
                ComboBox1102.Items.Add("/")
                ComboBox1102.Enabled = True
                ComboBox1103.Items.Clear()
                TextBox110.Text = ""
            End If
        End If
    End Sub

    Private Sub ComboBox1102_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1102.SelectedIndexChanged
        Dim value1 As String
        Dim value2 As String
        Dim v1 As Integer
        Dim v2 As Integer
        value1 = ComboBox1101.SelectedItem
        value2 = ComboBox1102.SelectedItem
        If Not String.IsNullOrEmpty(value1) And Not String.IsNullOrEmpty(value2) Then
            If value1.Equals("X") Then
                ComboBox1103.Enabled = True
                If Not value2.Equals("X") Then
                    ComboBox1103.Items.Clear()
                    For i As Integer = 0 To (9 - CInt(value2)) Step 1
                        ComboBox1103.Items.Add(i)
                    Next
                    ComboBox1103.Items.Add("/")
                Else
                    ComboBox1103.Items.Clear()
                    For i As Integer = 0 To 9 Step 1
                        ComboBox1103.Items.Add(i)
                    Next
                    ComboBox1103.Items.Add("X")
                End If
                TextBox110.Text = ""
            Else
                If value2.Equals("/") Then
                    ComboBox1103.Items.Clear()
                    For i As Integer = 0 To 9 Step 1
                        ComboBox1103.Items.Add(i)
                    Next
                    ComboBox1103.Items.Add("X")
                    ComboBox1103.Enabled = True
                    TextBox110.Text = ""
                Else
                    v1 = CInt(value1)
                    v2 = CInt(value2)
                    ComboBox1103.Enabled = False
                    ComboBox1103.Items.Clear()
                    Calculate(TextBox110, TextBox19, TextBox18, 10, v1, v2, 0, 1)
                End If
            End If
        End If
    End Sub

    Private Sub ComboBox1103_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1103.SelectedIndexChanged
        Dim value1 As String
        Dim value2 As String
        Dim value3 As String
        Dim v1 As Integer
        Dim v2 As Integer
        Dim v3 As Integer
        value1 = ComboBox1101.SelectedItem
        value2 = ComboBox1102.SelectedItem
        value3 = ComboBox1103.SelectedItem
        If Not String.IsNullOrEmpty(value1) And Not String.IsNullOrEmpty(value2) And Not String.IsNullOrEmpty(value3) Then
            If value1.Equals("X") Then
                v1 = 10
            Else
                v1 = CInt(value1)
            End If

            If value2.Equals("X") Then
                v2 = 10
            ElseIf value2.Equals("/") Then
                v2 = 10 - v1
            Else
                v2 = CInt(value2)
            End If

            If value3.Equals("X") Then
                v3 = 10
            ElseIf value3.Equals("/") Then
                v3 = 10 - v2
            Else
                v3 = CInt(value3)
            End If

            Calculate(TextBox110, TextBox19, TextBox18, 10, v1, v2, v3, 1)
        End If
    End Sub

    Private Sub ComboBox211_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox211.SelectedIndexChanged
        Dim value As String
        value = ComboBox211.SelectedItem
        If Not String.IsNullOrEmpty(value) Then
            If value.Equals("X") Then
                Calculate(TextBox21, TextBox21, TextBox21, 1, 10, 0, 0, 2)
                ComboBox212.Items.Clear()
                ComboBox212.Enabled = False
                ComboBox221.Enabled = True
            Else
                ComboBox212.Items.Clear()
                For i As Integer = 0 To (9 - value) Step 1
                    ComboBox212.Items.Add(i)
                Next
                ComboBox212.Items.Add("/")
                ComboBox212.Enabled = True
            End If
        End If
    End Sub

    Private Sub ComboBox212_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox212.SelectedIndexChanged
        Dim v1 As Integer
        Dim value2 As String
        Dim v2 As Integer
        v1 = ComboBox211.SelectedItem
        value2 = ComboBox212.SelectedItem
        If Not String.IsNullOrEmpty(value2) And Not String.IsNullOrEmpty(v1) Then
            If value2.Equals("/") Then
                v2 = 10 - v1
            Else
                v2 = CInt(value2)
            End If
            Calculate(TextBox21, TextBox21, TextBox21, 1, v1, v2, 0, 2)
            ComboBox221.Enabled = True
        End If
    End Sub

    Private Sub ComboBox221_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox221.SelectedIndexChanged
        Dim value As String
        value = ComboBox221.SelectedItem
        If Not String.IsNullOrEmpty(value) Then
            If value.Equals("X") Then
                Calculate(TextBox22, TextBox21, TextBox21, 2, 10, 0, 0, 2)
                ComboBox222.Items.Clear()
                ComboBox222.Enabled = False
                ComboBox231.Enabled = True
            Else
                ComboBox222.Items.Clear()
                For i As Integer = 0 To (9 - value) Step 1
                    ComboBox222.Items.Add(i)
                Next
                ComboBox222.Items.Add("/")
                ComboBox222.Enabled = True
            End If
        End If
    End Sub

    Private Sub ComboBox222_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox222.SelectedIndexChanged
        Dim v1 As Integer
        Dim value2 As String
        Dim v2 As Integer
        v1 = ComboBox221.SelectedItem
        value2 = ComboBox222.SelectedItem
        If Not String.IsNullOrEmpty(value2) And Not String.IsNullOrEmpty(v1) Then
            If value2.Equals("/") Then
                v2 = 10 - v1
            Else
                v2 = CInt(value2)
            End If
            Calculate(TextBox22, TextBox21, TextBox21, 2, v1, v2, 0, 2)
            ComboBox231.Enabled = True
        End If
    End Sub

    Private Sub ComboBox231_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox231.SelectedIndexChanged
        Dim value As String
        value = ComboBox231.SelectedItem
        If Not String.IsNullOrEmpty(value) Then
            If value.Equals("X") Then
                Calculate(TextBox23, TextBox22, TextBox21, 3, 10, 0, 0, 2)
                ComboBox232.Items.Clear()
                ComboBox232.Enabled = False
                ComboBox241.Enabled = True
            Else
                ComboBox232.Items.Clear()
                For i As Integer = 0 To (9 - value) Step 1
                    ComboBox232.Items.Add(i)
                Next
                ComboBox232.Items.Add("/")
                ComboBox232.Enabled = True
            End If
        End If
    End Sub

    Private Sub ComboBox232_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox232.SelectedIndexChanged
        Dim v1 As Integer
        Dim value2 As String
        Dim v2 As Integer
        v1 = ComboBox231.SelectedItem
        value2 = ComboBox232.SelectedItem
        If Not String.IsNullOrEmpty(value2) And Not String.IsNullOrEmpty(v1) Then
            If value2.Equals("/") Then
                v2 = 10 - v1
            Else
                v2 = CInt(value2)
            End If
            Calculate(TextBox23, TextBox22, TextBox21, 3, v1, v2, 0, 2)
            ComboBox241.Enabled = True
        End If
    End Sub

    Private Sub ComboBox241_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox241.SelectedIndexChanged
        Dim value As String
        value = ComboBox241.SelectedItem
        If Not String.IsNullOrEmpty(value) Then
            If value.Equals("X") Then
                Calculate(TextBox24, TextBox23, TextBox22, 4, 10, 0, 0, 2)
                ComboBox242.Items.Clear()
                ComboBox242.Enabled = False
                ComboBox251.Enabled = True
            Else
                ComboBox242.Items.Clear()
                For i As Integer = 0 To (9 - value) Step 1
                    ComboBox242.Items.Add(i)
                Next
                ComboBox242.Items.Add("/")
                ComboBox242.Enabled = True
            End If
        End If
    End Sub

    Private Sub ComboBox242_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox242.SelectedIndexChanged
        Dim v1 As Integer
        Dim value2 As String
        Dim v2 As Integer
        v1 = ComboBox241.SelectedItem
        value2 = ComboBox242.SelectedItem
        If Not String.IsNullOrEmpty(value2) And Not String.IsNullOrEmpty(v1) Then
            If value2.Equals("/") Then
                v2 = 10 - v1
            Else
                v2 = CInt(value2)
            End If
            Calculate(TextBox24, TextBox23, TextBox22, 4, v1, v2, 0, 2)
            ComboBox251.Enabled = True
        End If
    End Sub

    Private Sub ComboBox251_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox251.SelectedIndexChanged
        Dim value As String
        value = ComboBox251.SelectedItem
        If Not String.IsNullOrEmpty(value) Then
            If value.Equals("X") Then
                Calculate(TextBox25, TextBox24, TextBox23, 5, 10, 0, 0, 2)
                ComboBox252.Items.Clear()
                ComboBox252.Enabled = False
                ComboBox261.Enabled = True
            Else
                ComboBox252.Items.Clear()
                For i As Integer = 0 To (9 - value) Step 1
                    ComboBox252.Items.Add(i)
                Next
                ComboBox252.Items.Add("/")
                ComboBox252.Enabled = True
            End If
        End If
    End Sub

    Private Sub ComboBox252_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox252.SelectedIndexChanged
        Dim v1 As Integer
        Dim value2 As String
        Dim v2 As Integer
        v1 = ComboBox251.SelectedItem
        value2 = ComboBox252.SelectedItem
        If Not String.IsNullOrEmpty(value2) And Not String.IsNullOrEmpty(v1) Then
            If value2.Equals("/") Then
                v2 = 10 - v1
            Else
                v2 = CInt(value2)
            End If
            Calculate(TextBox25, TextBox24, TextBox23, 5, v1, v2, 0, 2)
            ComboBox261.Enabled = True
        End If
    End Sub

    Private Sub ComboBox261_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox261.SelectedIndexChanged
        Dim value As String
        value = ComboBox261.SelectedItem
        If Not String.IsNullOrEmpty(value) Then
            If value.Equals("X") Then
                Calculate(TextBox26, TextBox25, TextBox24, 6, 10, 0, 0, 2)
                ComboBox262.Items.Clear()
                ComboBox262.Enabled = False
                ComboBox271.Enabled = True
            Else
                ComboBox262.Items.Clear()
                For i As Integer = 0 To (9 - value) Step 1
                    ComboBox262.Items.Add(i)
                Next
                ComboBox262.Items.Add("/")
                ComboBox262.Enabled = True
            End If
        End If
    End Sub

    Private Sub ComboBox262_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox262.SelectedIndexChanged
        Dim v1 As Integer
        Dim value2 As String
        Dim v2 As Integer
        v1 = ComboBox261.SelectedItem
        value2 = ComboBox262.SelectedItem
        If Not String.IsNullOrEmpty(value2) And Not String.IsNullOrEmpty(v1) Then
            If value2.Equals("/") Then
                v2 = 10 - v1
            Else
                v2 = CInt(value2)
            End If
            Calculate(TextBox26, TextBox25, TextBox24, 6, v1, v2, 0, 2)
            ComboBox271.Enabled = True
        End If
    End Sub

    Private Sub ComboBox271_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox271.SelectedIndexChanged
        Dim value As String
        value = ComboBox271.SelectedItem
        If Not String.IsNullOrEmpty(value) Then
            If value.Equals("X") Then
                Calculate(TextBox27, TextBox26, TextBox25, 7, 10, 0, 0, 2)
                ComboBox272.Items.Clear()
                ComboBox272.Enabled = False
                ComboBox281.Enabled = True
            Else
                ComboBox272.Items.Clear()
                For i As Integer = 0 To (9 - value) Step 1
                    ComboBox272.Items.Add(i)
                Next
                ComboBox272.Items.Add("/")
                ComboBox272.Enabled = True
            End If
        End If
    End Sub

    Private Sub ComboBox272_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox272.SelectedIndexChanged
        Dim v1 As Integer
        Dim value2 As String
        Dim v2 As Integer
        v1 = ComboBox271.SelectedItem
        value2 = ComboBox272.SelectedItem
        If Not String.IsNullOrEmpty(value2) And Not String.IsNullOrEmpty(v1) Then
            If value2.Equals("/") Then
                v2 = 10 - v1
            Else
                v2 = CInt(value2)
            End If
            Calculate(TextBox27, TextBox26, TextBox25, 7, v1, v2, 0, 2)
            ComboBox281.Enabled = True
        End If
    End Sub

    Private Sub ComboBox281_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox281.SelectedIndexChanged
        Dim value As String
        value = ComboBox281.SelectedItem
        If Not String.IsNullOrEmpty(value) Then
            If value.Equals("X") Then
                Calculate(TextBox28, TextBox27, TextBox26, 8, 10, 0, 0, 2)
                ComboBox282.Items.Clear()
                ComboBox282.Enabled = False
                ComboBox291.Enabled = True
            Else
                ComboBox282.Items.Clear()
                For i As Integer = 0 To (9 - value) Step 1
                    ComboBox282.Items.Add(i)
                Next
                ComboBox282.Items.Add("/")
                ComboBox282.Enabled = True
            End If
        End If
    End Sub

    Private Sub ComboBox282_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox282.SelectedIndexChanged
        Dim v1 As Integer
        Dim value2 As String
        Dim v2 As Integer
        v1 = ComboBox281.SelectedItem
        value2 = ComboBox282.SelectedItem
        If Not String.IsNullOrEmpty(value2) And Not String.IsNullOrEmpty(v1) Then
            If value2.Equals("/") Then
                v2 = 10 - v1
            Else
                v2 = CInt(value2)
            End If
            Calculate(TextBox28, TextBox27, TextBox26, 8, v1, v2, 0, 2)
            ComboBox291.Enabled = True
        End If
    End Sub

    Private Sub ComboBox291_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox291.SelectedIndexChanged
        Dim value As String
        value = ComboBox291.SelectedItem
        If Not String.IsNullOrEmpty(value) Then
            If value.Equals("X") Then
                Calculate(TextBox29, TextBox28, TextBox27, 9, 10, 0, 0, 2)
                ComboBox292.Items.Clear()
                ComboBox292.Enabled = False
                ComboBox2101.Enabled = True
            Else
                ComboBox292.Items.Clear()
                For i As Integer = 0 To (9 - value) Step 1
                    ComboBox292.Items.Add(i)
                Next
                ComboBox292.Items.Add("/")
                ComboBox292.Enabled = True
            End If
        End If
    End Sub

    Private Sub ComboBox292_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox292.SelectedIndexChanged
        Dim v1 As Integer
        Dim value2 As String
        Dim v2 As Integer
        v1 = ComboBox291.SelectedItem
        value2 = ComboBox292.SelectedItem
        If Not String.IsNullOrEmpty(value2) And Not String.IsNullOrEmpty(v1) Then
            If value2.Equals("/") Then
                v2 = 10 - v1
            Else
                v2 = CInt(value2)
            End If
            Calculate(TextBox29, TextBox28, TextBox27, 9, v1, v2, 0, 2)
            ComboBox2101.Enabled = True
        End If
    End Sub

    Private Sub ComboBox2101_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2101.SelectedIndexChanged
        Dim value As String
        value = ComboBox2101.SelectedItem
        If Not String.IsNullOrEmpty(value) Then
            If value.Equals("X") Then
                ComboBox2102.Items.Clear()
                For i As Integer = 0 To 9 Step 1
                    ComboBox2102.Items.Add(i)
                Next
                ComboBox2102.Items.Add("X")
                ComboBox2102.Enabled = True
                ComboBox2103.Items.Clear()
                TextBox210.Text = ""
            Else
                ComboBox2102.Items.Clear()
                For i As Integer = 0 To (9 - value) Step 1
                    ComboBox2102.Items.Add(i)
                Next
                ComboBox2102.Items.Add("/")
                ComboBox2102.Enabled = True
                ComboBox2103.Items.Clear()
                TextBox210.Text = ""
            End If
        End If
    End Sub

    Private Sub ComboBox2102_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2102.SelectedIndexChanged
        Dim value1 As String
        Dim value2 As String
        Dim v1 As Integer
        Dim v2 As Integer
        value1 = ComboBox2101.SelectedItem
        value2 = ComboBox2102.SelectedItem
        If Not String.IsNullOrEmpty(value1) And Not String.IsNullOrEmpty(value2) Then
            If value1.Equals("X") Then
                ComboBox2103.Enabled = True
                If Not value2.Equals("X") Then
                    ComboBox2103.Items.Clear()
                    For i As Integer = 0 To (9 - CInt(value2)) Step 1
                        ComboBox2103.Items.Add(i)
                    Next
                    ComboBox2103.Items.Add("/")
                Else
                    ComboBox2103.Items.Clear()
                    For i As Integer = 0 To 9 Step 1
                        ComboBox2103.Items.Add(i)
                    Next
                    ComboBox2103.Items.Add("X")
                End If
                TextBox210.Text = ""
            Else
                If value2.Equals("/") Then
                    ComboBox2103.Items.Clear()
                    For i As Integer = 0 To 9 Step 1
                        ComboBox2103.Items.Add(i)
                    Next
                    ComboBox2103.Items.Add("X")
                    ComboBox2103.Enabled = True
                    TextBox210.Text = ""
                Else
                    v1 = CInt(value1)
                    v2 = CInt(value2)
                    ComboBox2103.Enabled = False
                    ComboBox2103.Items.Clear()
                    Calculate(TextBox210, TextBox29, TextBox28, 10, v1, v2, 0, 2)
                End If
            End If
        End If
    End Sub

    Private Sub ComboBox2103_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2103.SelectedIndexChanged
        Dim value1 As String
        Dim value2 As String
        Dim value3 As String
        Dim v1 As Integer
        Dim v2 As Integer
        Dim v3 As Integer
        value1 = ComboBox2101.SelectedItem
        value2 = ComboBox2102.SelectedItem
        value3 = ComboBox2103.SelectedItem
        If Not String.IsNullOrEmpty(value1) And Not String.IsNullOrEmpty(value2) And Not String.IsNullOrEmpty(value3) Then
            If value1.Equals("X") Then
                v1 = 10
            Else
                v1 = CInt(value1)
            End If

            If value2.Equals("X") Then
                v2 = 10
            ElseIf value2.Equals("/") Then
                v2 = 10 - v1
            Else
                v2 = CInt(value2)
            End If

            If value3.Equals("X") Then
                v3 = 10
            ElseIf value3.Equals("/") Then
                v3 = 10 - v2
            Else
                v3 = CInt(value3)
            End If

            Calculate(TextBox210, TextBox29, TextBox28, 10, v1, v2, v3, 2)
        End If
    End Sub

    Private Sub ComboBox311_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox311.SelectedIndexChanged
        Dim value As String
        value = ComboBox311.SelectedItem
        If Not String.IsNullOrEmpty(value) Then
            If value.Equals("X") Then
                Calculate(TextBox31, TextBox31, TextBox31, 1, 10, 0, 0, 3)
                ComboBox312.Items.Clear()
                ComboBox312.Enabled = False
                ComboBox321.Enabled = True
            Else
                ComboBox312.Items.Clear()
                For i As Integer = 0 To (9 - value) Step 1
                    ComboBox312.Items.Add(i)
                Next
                ComboBox312.Items.Add("/")
                ComboBox312.Enabled = True
            End If
        End If
    End Sub

    Private Sub ComboBox312_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox312.SelectedIndexChanged
        Dim v1 As Integer
        Dim value2 As String
        Dim v2 As Integer
        v1 = ComboBox311.SelectedItem
        value2 = ComboBox312.SelectedItem
        If Not String.IsNullOrEmpty(value2) And Not String.IsNullOrEmpty(v1) Then
            If value2.Equals("/") Then
                v2 = 10 - v1
            Else
                v2 = CInt(value2)
            End If
            Calculate(TextBox31, TextBox31, TextBox31, 1, v1, v2, 0, 3)
            ComboBox321.Enabled = True
        End If
    End Sub

    Private Sub ComboBox321_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox321.SelectedIndexChanged
        Dim value As String
        value = ComboBox321.SelectedItem
        If Not String.IsNullOrEmpty(value) Then
            If value.Equals("X") Then
                Calculate(TextBox32, TextBox31, TextBox31, 2, 10, 0, 0, 3)
                ComboBox322.Items.Clear()
                ComboBox322.Enabled = False
                ComboBox331.Enabled = True
            Else
                ComboBox322.Items.Clear()
                For i As Integer = 0 To (9 - value) Step 1
                    ComboBox322.Items.Add(i)
                Next
                ComboBox322.Items.Add("/")
                ComboBox322.Enabled = True
            End If
        End If
    End Sub

    Private Sub ComboBox322_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox322.SelectedIndexChanged
        Dim v1 As Integer
        Dim value2 As String
        Dim v2 As Integer
        v1 = ComboBox321.SelectedItem
        value2 = ComboBox322.SelectedItem
        If Not String.IsNullOrEmpty(value2) And Not String.IsNullOrEmpty(v1) Then
            If value2.Equals("/") Then
                v2 = 10 - v1
            Else
                v2 = CInt(value2)
            End If
            Calculate(TextBox32, TextBox31, TextBox31, 2, v1, v2, 0, 3)
            ComboBox331.Enabled = True
        End If
    End Sub

    Private Sub ComboBox331_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox331.SelectedIndexChanged
        Dim value As String
        value = ComboBox331.SelectedItem
        If Not String.IsNullOrEmpty(value) Then
            If value.Equals("X") Then
                Calculate(TextBox33, TextBox32, TextBox31, 3, 10, 0, 0, 3)
                ComboBox332.Items.Clear()
                ComboBox332.Enabled = False
                ComboBox341.Enabled = True
            Else
                ComboBox332.Items.Clear()
                For i As Integer = 0 To (9 - value) Step 1
                    ComboBox332.Items.Add(i)
                Next
                ComboBox332.Items.Add("/")
                ComboBox332.Enabled = True
            End If
        End If
    End Sub

    Private Sub ComboBox332_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox332.SelectedIndexChanged
        Dim v1 As Integer
        Dim value2 As String
        Dim v2 As Integer
        v1 = ComboBox331.SelectedItem
        value2 = ComboBox332.SelectedItem
        If Not String.IsNullOrEmpty(value2) And Not String.IsNullOrEmpty(v1) Then
            If value2.Equals("/") Then
                v2 = 10 - v1
            Else
                v2 = CInt(value2)
            End If
            Calculate(TextBox33, TextBox32, TextBox31, 3, v1, v2, 0, 3)
            ComboBox341.Enabled = True
        End If
    End Sub

    Private Sub ComboBox341_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox341.SelectedIndexChanged
        Dim value As String
        value = ComboBox341.SelectedItem
        If Not String.IsNullOrEmpty(value) Then
            If value.Equals("X") Then
                Calculate(TextBox34, TextBox33, TextBox32, 4, 10, 0, 0, 3)
                ComboBox342.Items.Clear()
                ComboBox342.Enabled = False
                ComboBox351.Enabled = True
            Else
                ComboBox342.Items.Clear()
                For i As Integer = 0 To (9 - value) Step 1
                    ComboBox342.Items.Add(i)
                Next
                ComboBox342.Items.Add("/")
                ComboBox342.Enabled = True
            End If
        End If
    End Sub

    Private Sub ComboBox342_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox342.SelectedIndexChanged
        Dim v1 As Integer
        Dim value2 As String
        Dim v2 As Integer
        v1 = ComboBox341.SelectedItem
        value2 = ComboBox342.SelectedItem
        If Not String.IsNullOrEmpty(value2) And Not String.IsNullOrEmpty(v1) Then
            If value2.Equals("/") Then
                v2 = 10 - v1
            Else
                v2 = CInt(value2)
            End If
            Calculate(TextBox34, TextBox33, TextBox32, 4, v1, v2, 0, 3)
            ComboBox351.Enabled = True
        End If
    End Sub

    Private Sub ComboBox351_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox351.SelectedIndexChanged
        Dim value As String
        value = ComboBox351.SelectedItem
        If Not String.IsNullOrEmpty(value) Then
            If value.Equals("X") Then
                Calculate(TextBox35, TextBox34, TextBox33, 5, 10, 0, 0, 3)
                ComboBox352.Items.Clear()
                ComboBox352.Enabled = False
                ComboBox361.Enabled = True
            Else
                ComboBox352.Items.Clear()
                For i As Integer = 0 To (9 - value) Step 1
                    ComboBox352.Items.Add(i)
                Next
                ComboBox352.Items.Add("/")
                ComboBox352.Enabled = True
            End If
        End If
    End Sub

    Private Sub ComboBox352_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox352.SelectedIndexChanged
        Dim v1 As Integer
        Dim value2 As String
        Dim v2 As Integer
        v1 = ComboBox351.SelectedItem
        value2 = ComboBox352.SelectedItem
        If Not String.IsNullOrEmpty(value2) And Not String.IsNullOrEmpty(v1) Then
            If value2.Equals("/") Then
                v2 = 10 - v1
            Else
                v2 = CInt(value2)
            End If
            Calculate(TextBox35, TextBox34, TextBox33, 5, v1, v2, 0, 3)
            ComboBox361.Enabled = True
        End If
    End Sub

    Private Sub ComboBox361_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox361.SelectedIndexChanged
        Dim value As String
        value = ComboBox361.SelectedItem
        If Not String.IsNullOrEmpty(value) Then
            If value.Equals("X") Then
                Calculate(TextBox36, TextBox35, TextBox34, 6, 10, 0, 0, 3)
                ComboBox362.Items.Clear()
                ComboBox362.Enabled = False
                ComboBox371.Enabled = True
            Else
                ComboBox362.Items.Clear()
                For i As Integer = 0 To (9 - value) Step 1
                    ComboBox362.Items.Add(i)
                Next
                ComboBox362.Items.Add("/")
                ComboBox362.Enabled = True
            End If
        End If
    End Sub

    Private Sub ComboBox362_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox362.SelectedIndexChanged
        Dim v1 As Integer
        Dim value2 As String
        Dim v2 As Integer
        v1 = ComboBox361.SelectedItem
        value2 = ComboBox362.SelectedItem
        If Not String.IsNullOrEmpty(value2) And Not String.IsNullOrEmpty(v1) Then
            If value2.Equals("/") Then
                v2 = 10 - v1
            Else
                v2 = CInt(value2)
            End If
            Calculate(TextBox36, TextBox35, TextBox34, 6, v1, v2, 0, 3)
            ComboBox371.Enabled = True
        End If
    End Sub

    Private Sub ComboBox371_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox371.SelectedIndexChanged
        Dim value As String
        value = ComboBox371.SelectedItem
        If Not String.IsNullOrEmpty(value) Then
            If value.Equals("X") Then
                Calculate(TextBox37, TextBox36, TextBox35, 7, 10, 0, 0, 3)
                ComboBox372.Items.Clear()
                ComboBox372.Enabled = False
                ComboBox381.Enabled = True
            Else
                ComboBox372.Items.Clear()
                For i As Integer = 0 To (9 - value) Step 1
                    ComboBox372.Items.Add(i)
                Next
                ComboBox372.Items.Add("/")
                ComboBox372.Enabled = True
            End If
        End If
    End Sub

    Private Sub ComboBox372_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox372.SelectedIndexChanged
        Dim v1 As Integer
        Dim value2 As String
        Dim v2 As Integer
        v1 = ComboBox371.SelectedItem
        value2 = ComboBox372.SelectedItem
        If Not String.IsNullOrEmpty(value2) And Not String.IsNullOrEmpty(v1) Then
            If value2.Equals("/") Then
                v2 = 10 - v1
            Else
                v2 = CInt(value2)
            End If
            Calculate(TextBox37, TextBox36, TextBox35, 7, v1, v2, 0, 3)
            ComboBox381.Enabled = True
        End If
    End Sub

    Private Sub ComboBox381_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox381.SelectedIndexChanged
        Dim value As String
        value = ComboBox381.SelectedItem
        If Not String.IsNullOrEmpty(value) Then
            If value.Equals("X") Then
                Calculate(TextBox38, TextBox37, TextBox36, 8, 10, 0, 0, 3)
                ComboBox382.Items.Clear()
                ComboBox382.Enabled = False
                ComboBox391.Enabled = True
            Else
                ComboBox382.Items.Clear()
                For i As Integer = 0 To (9 - value) Step 1
                    ComboBox382.Items.Add(i)
                Next
                ComboBox382.Items.Add("/")
                ComboBox382.Enabled = True
            End If
        End If
    End Sub

    Private Sub ComboBox382_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox382.SelectedIndexChanged
        Dim v1 As Integer
        Dim value2 As String
        Dim v2 As Integer
        v1 = ComboBox381.SelectedItem
        value2 = ComboBox382.SelectedItem
        If Not String.IsNullOrEmpty(value2) And Not String.IsNullOrEmpty(v1) Then
            If value2.Equals("/") Then
                v2 = 10 - v1
            Else
                v2 = CInt(value2)
            End If
            Calculate(TextBox38, TextBox37, TextBox36, 8, v1, v2, 0, 3)
            ComboBox391.Enabled = True
        End If
    End Sub

    Private Sub ComboBox391_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox391.SelectedIndexChanged
        Dim value As String
        value = ComboBox391.SelectedItem
        If Not String.IsNullOrEmpty(value) Then
            If value.Equals("X") Then
                Calculate(TextBox39, TextBox38, TextBox37, 9, 10, 0, 0, 3)
                ComboBox392.Items.Clear()
                ComboBox392.Enabled = False
                ComboBox3101.Enabled = True
            Else
                ComboBox392.Items.Clear()
                For i As Integer = 0 To (9 - value) Step 1
                    ComboBox392.Items.Add(i)
                Next
                ComboBox392.Items.Add("/")
                ComboBox392.Enabled = True
            End If
        End If
    End Sub

    Private Sub ComboBox392_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox392.SelectedIndexChanged
        Dim v1 As Integer
        Dim value2 As String
        Dim v2 As Integer
        v1 = ComboBox391.SelectedItem
        value2 = ComboBox392.SelectedItem
        If Not String.IsNullOrEmpty(value2) And Not String.IsNullOrEmpty(v1) Then
            If value2.Equals("/") Then
                v2 = 10 - v1
            Else
                v2 = CInt(value2)
            End If
            Calculate(TextBox39, TextBox38, TextBox37, 9, v1, v2, 0, 3)
            ComboBox3101.Enabled = True
        End If
    End Sub

    Private Sub ComboBox3101_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3101.SelectedIndexChanged
        Dim value As String
        value = ComboBox3101.SelectedItem
        If Not String.IsNullOrEmpty(value) Then
            If value.Equals("X") Then
                ComboBox3102.Items.Clear()
                For i As Integer = 0 To 9 Step 1
                    ComboBox3102.Items.Add(i)
                Next
                ComboBox3102.Items.Add("X")
                ComboBox3102.Enabled = True
                ComboBox3103.Items.Clear()
                TextBox310.Text = ""
            Else
                ComboBox3102.Items.Clear()
                For i As Integer = 0 To (9 - value) Step 1
                    ComboBox3102.Items.Add(i)
                Next
                ComboBox3102.Items.Add("/")
                ComboBox3102.Enabled = True
                ComboBox3103.Items.Clear()
                TextBox310.Text = ""
            End If
        End If
    End Sub

    Private Sub ComboBox3102_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3102.SelectedIndexChanged
        Dim value1 As String
        Dim value2 As String
        Dim v1 As Integer
        Dim v2 As Integer
        value1 = ComboBox3101.SelectedItem
        value2 = ComboBox3102.SelectedItem
        If Not String.IsNullOrEmpty(value1) And Not String.IsNullOrEmpty(value2) Then
            If value1.Equals("X") Then
                ComboBox3103.Enabled = True
                If Not value2.Equals("X") Then
                    ComboBox3103.Items.Clear()
                    For i As Integer = 0 To (9 - CInt(value2)) Step 1
                        ComboBox3103.Items.Add(i)
                    Next
                    ComboBox3103.Items.Add("/")
                Else
                    ComboBox3103.Items.Clear()
                    For i As Integer = 0 To 9 Step 1
                        ComboBox3103.Items.Add(i)
                    Next
                    ComboBox3103.Items.Add("X")
                End If
                TextBox310.Text = ""
            Else
                If value2.Equals("/") Then
                    ComboBox3103.Items.Clear()
                    For i As Integer = 0 To 9 Step 1
                        ComboBox3103.Items.Add(i)
                    Next
                    ComboBox3103.Items.Add("X")
                    ComboBox3103.Enabled = True
                    TextBox310.Text = ""
                Else
                    v1 = CInt(value1)
                    v2 = CInt(value2)
                    ComboBox3103.Enabled = False
                    ComboBox3103.Items.Clear()
                    Calculate(TextBox310, TextBox39, TextBox38, 10, v1, v2, 0, 3)
                End If
            End If
        End If
    End Sub

    Private Sub ComboBox3103_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3103.SelectedIndexChanged
        Dim value1 As String
        Dim value2 As String
        Dim value3 As String
        Dim v1 As Integer
        Dim v2 As Integer
        Dim v3 As Integer
        value1 = ComboBox3101.SelectedItem
        value2 = ComboBox3102.SelectedItem
        value3 = ComboBox3103.SelectedItem
        If Not String.IsNullOrEmpty(value1) And Not String.IsNullOrEmpty(value2) And Not String.IsNullOrEmpty(value3) Then
            If value1.Equals("X") Then
                v1 = 10
            Else
                v1 = CInt(value1)
            End If

            If value2.Equals("X") Then
                v2 = 10
            ElseIf value2.Equals("/") Then
                v2 = 10 - v1
            Else
                v2 = CInt(value2)
            End If

            If value3.Equals("X") Then
                v3 = 10
            ElseIf value3.Equals("/") Then
                v3 = 10 - v2
            Else
                v3 = CInt(value3)
            End If

            Calculate(TextBox310, TextBox39, TextBox38, 10, v1, v2, v3, 3)
        End If
    End Sub

    Private Sub ComboBox411_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox411.SelectedIndexChanged
        Dim value As String
        value = ComboBox411.SelectedItem
        If Not String.IsNullOrEmpty(value) Then
            If value.Equals("X") Then
                Calculate(TextBox41, TextBox41, TextBox41, 1, 10, 0, 0, 4)
                ComboBox412.Items.Clear()
                ComboBox412.Enabled = False
                ComboBox421.Enabled = True
            Else
                ComboBox412.Items.Clear()
                For i As Integer = 0 To (9 - value) Step 1
                    ComboBox412.Items.Add(i)
                Next
                ComboBox412.Items.Add("/")
                ComboBox412.Enabled = True
            End If
        End If
    End Sub

    Private Sub ComboBox412_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox412.SelectedIndexChanged
        Dim v1 As Integer
        Dim value2 As String
        Dim v2 As Integer
        v1 = ComboBox411.SelectedItem
        value2 = ComboBox412.SelectedItem
        If Not String.IsNullOrEmpty(value2) And Not String.IsNullOrEmpty(v1) Then
            If value2.Equals("/") Then
                v2 = 10 - v1
            Else
                v2 = CInt(value2)
            End If
            Calculate(TextBox41, TextBox41, TextBox41, 1, v1, v2, 0, 4)
            ComboBox421.Enabled = True
        End If
    End Sub

    Private Sub ComboBox421_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox421.SelectedIndexChanged
        Dim value As String
        value = ComboBox421.SelectedItem
        If Not String.IsNullOrEmpty(value) Then
            If value.Equals("X") Then
                Calculate(TextBox42, TextBox41, TextBox41, 2, 10, 0, 0, 4)
                ComboBox422.Items.Clear()
                ComboBox422.Enabled = False
                ComboBox431.Enabled = True
            Else
                ComboBox422.Items.Clear()
                For i As Integer = 0 To (9 - value) Step 1
                    ComboBox422.Items.Add(i)
                Next
                ComboBox422.Items.Add("/")
                ComboBox422.Enabled = True
            End If
        End If
    End Sub

    Private Sub ComboBox422_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox422.SelectedIndexChanged
        Dim v1 As Integer
        Dim value2 As String
        Dim v2 As Integer
        v1 = ComboBox421.SelectedItem
        value2 = ComboBox422.SelectedItem
        If Not String.IsNullOrEmpty(value2) And Not String.IsNullOrEmpty(v1) Then
            If value2.Equals("/") Then
                v2 = 10 - v1
            Else
                v2 = CInt(value2)
            End If
            Calculate(TextBox42, TextBox41, TextBox41, 2, v1, v2, 0, 4)
            ComboBox431.Enabled = True
        End If
    End Sub

    Private Sub ComboBox431_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox431.SelectedIndexChanged
        Dim value As String
        value = ComboBox431.SelectedItem
        If Not String.IsNullOrEmpty(value) Then
            If value.Equals("X") Then
                Calculate(TextBox43, TextBox42, TextBox41, 3, 10, 0, 0, 4)
                ComboBox432.Items.Clear()
                ComboBox432.Enabled = False
                ComboBox441.Enabled = True
            Else
                ComboBox432.Items.Clear()
                For i As Integer = 0 To (9 - value) Step 1
                    ComboBox432.Items.Add(i)
                Next
                ComboBox432.Items.Add("/")
                ComboBox432.Enabled = True
            End If
        End If
    End Sub

    Private Sub ComboBox432_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox432.SelectedIndexChanged
        Dim v1 As Integer
        Dim value2 As String
        Dim v2 As Integer
        v1 = ComboBox431.SelectedItem
        value2 = ComboBox432.SelectedItem
        If Not String.IsNullOrEmpty(value2) And Not String.IsNullOrEmpty(v1) Then
            If value2.Equals("/") Then
                v2 = 10 - v1
            Else
                v2 = CInt(value2)
            End If
            Calculate(TextBox43, TextBox42, TextBox41, 3, v1, v2, 0, 4)
            ComboBox441.Enabled = True
        End If
    End Sub

    Private Sub ComboBox441_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox441.SelectedIndexChanged
        Dim value As String
        value = ComboBox441.SelectedItem
        If Not String.IsNullOrEmpty(value) Then
            If value.Equals("X") Then
                Calculate(TextBox44, TextBox43, TextBox42, 4, 10, 0, 0, 4)
                ComboBox442.Items.Clear()
                ComboBox442.Enabled = False
                ComboBox451.Enabled = True
            Else
                ComboBox442.Items.Clear()
                For i As Integer = 0 To (9 - value) Step 1
                    ComboBox442.Items.Add(i)
                Next
                ComboBox442.Items.Add("/")
                ComboBox442.Enabled = True
            End If
        End If
    End Sub

    Private Sub ComboBox442_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox442.SelectedIndexChanged
        Dim v1 As Integer
        Dim value2 As String
        Dim v2 As Integer
        v1 = ComboBox441.SelectedItem
        value2 = ComboBox442.SelectedItem
        If Not String.IsNullOrEmpty(value2) And Not String.IsNullOrEmpty(v1) Then
            If value2.Equals("/") Then
                v2 = 10 - v1
            Else
                v2 = CInt(value2)
            End If
            Calculate(TextBox44, TextBox43, TextBox42, 4, v1, v2, 0, 4)
            ComboBox451.Enabled = True
        End If
    End Sub

    Private Sub ComboBox451_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox451.SelectedIndexChanged
        Dim value As String
        value = ComboBox451.SelectedItem
        If Not String.IsNullOrEmpty(value) Then
            If value.Equals("X") Then
                Calculate(TextBox45, TextBox44, TextBox43, 5, 10, 0, 0, 4)
                ComboBox452.Items.Clear()
                ComboBox452.Enabled = False
                ComboBox461.Enabled = True
            Else
                ComboBox452.Items.Clear()
                For i As Integer = 0 To (9 - value) Step 1
                    ComboBox452.Items.Add(i)
                Next
                ComboBox452.Items.Add("/")
                ComboBox452.Enabled = True
            End If
        End If
    End Sub

    Private Sub ComboBox452_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox452.SelectedIndexChanged
        Dim v1 As Integer
        Dim value2 As String
        Dim v2 As Integer
        v1 = ComboBox451.SelectedItem
        value2 = ComboBox452.SelectedItem
        If Not String.IsNullOrEmpty(value2) And Not String.IsNullOrEmpty(v1) Then
            If value2.Equals("/") Then
                v2 = 10 - v1
            Else
                v2 = CInt(value2)
            End If
            Calculate(TextBox45, TextBox44, TextBox43, 5, v1, v2, 0, 4)
            ComboBox461.Enabled = True
        End If
    End Sub

    Private Sub ComboBox461_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox461.SelectedIndexChanged
        Dim value As String
        value = ComboBox461.SelectedItem
        If Not String.IsNullOrEmpty(value) Then
            If value.Equals("X") Then
                Calculate(TextBox46, TextBox45, TextBox44, 6, 10, 0, 0, 4)
                ComboBox462.Items.Clear()
                ComboBox462.Enabled = False
                ComboBox471.Enabled = True
            Else
                ComboBox462.Items.Clear()
                For i As Integer = 0 To (9 - value) Step 1
                    ComboBox462.Items.Add(i)
                Next
                ComboBox462.Items.Add("/")
                ComboBox462.Enabled = True
            End If
        End If
    End Sub

    Private Sub ComboBox462_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox462.SelectedIndexChanged
        Dim v1 As Integer
        Dim value2 As String
        Dim v2 As Integer
        v1 = ComboBox461.SelectedItem
        value2 = ComboBox462.SelectedItem
        If Not String.IsNullOrEmpty(value2) And Not String.IsNullOrEmpty(v1) Then
            If value2.Equals("/") Then
                v2 = 10 - v1
            Else
                v2 = CInt(value2)
            End If
            Calculate(TextBox46, TextBox45, TextBox44, 6, v1, v2, 0, 4)
            ComboBox471.Enabled = True
        End If
    End Sub

    Private Sub ComboBox471_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox471.SelectedIndexChanged
        Dim value As String
        value = ComboBox471.SelectedItem
        If Not String.IsNullOrEmpty(value) Then
            If value.Equals("X") Then
                Calculate(TextBox47, TextBox46, TextBox45, 7, 10, 0, 0, 4)
                ComboBox472.Items.Clear()
                ComboBox472.Enabled = False
                ComboBox481.Enabled = True
            Else
                ComboBox472.Items.Clear()
                For i As Integer = 0 To (9 - value) Step 1
                    ComboBox472.Items.Add(i)
                Next
                ComboBox472.Items.Add("/")
                ComboBox472.Enabled = True
            End If
        End If
    End Sub

    Private Sub ComboBox472_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox472.SelectedIndexChanged
        Dim v1 As Integer
        Dim value2 As String
        Dim v2 As Integer
        v1 = ComboBox471.SelectedItem
        value2 = ComboBox472.SelectedItem
        If Not String.IsNullOrEmpty(value2) And Not String.IsNullOrEmpty(v1) Then
            If value2.Equals("/") Then
                v2 = 10 - v1
            Else
                v2 = CInt(value2)
            End If
            Calculate(TextBox47, TextBox46, TextBox45, 7, v1, v2, 0, 4)
            ComboBox481.Enabled = True
        End If
    End Sub

    Private Sub ComboBox481_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox481.SelectedIndexChanged
        Dim value As String
        value = ComboBox481.SelectedItem
        If Not String.IsNullOrEmpty(value) Then
            If value.Equals("X") Then
                Calculate(TextBox48, TextBox47, TextBox46, 8, 10, 0, 0, 4)
                ComboBox482.Items.Clear()
                ComboBox482.Enabled = False
                ComboBox491.Enabled = True
            Else
                ComboBox482.Items.Clear()
                For i As Integer = 0 To (9 - value) Step 1
                    ComboBox482.Items.Add(i)
                Next
                ComboBox482.Items.Add("/")
                ComboBox482.Enabled = True
            End If
        End If
    End Sub

    Private Sub ComboBox482_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox482.SelectedIndexChanged
        Dim v1 As Integer
        Dim value2 As String
        Dim v2 As Integer
        v1 = ComboBox481.SelectedItem
        value2 = ComboBox482.SelectedItem
        If Not String.IsNullOrEmpty(value2) And Not String.IsNullOrEmpty(v1) Then
            If value2.Equals("/") Then
                v2 = 10 - v1
            Else
                v2 = CInt(value2)
            End If
            Calculate(TextBox48, TextBox47, TextBox46, 8, v1, v2, 0, 4)
            ComboBox491.Enabled = True
        End If
    End Sub

    Private Sub ComboBox491_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox491.SelectedIndexChanged
        Dim value As String
        value = ComboBox491.SelectedItem
        If Not String.IsNullOrEmpty(value) Then
            If value.Equals("X") Then
                Calculate(TextBox49, TextBox48, TextBox47, 9, 10, 0, 0, 4)
                ComboBox492.Items.Clear()
                ComboBox492.Enabled = False
                ComboBox4101.Enabled = True
            Else
                ComboBox492.Items.Clear()
                For i As Integer = 0 To (9 - value) Step 1
                    ComboBox492.Items.Add(i)
                Next
                ComboBox492.Items.Add("/")
                ComboBox492.Enabled = True
            End If
        End If
    End Sub

    Private Sub ComboBox492_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox492.SelectedIndexChanged
        Dim v1 As Integer
        Dim value2 As String
        Dim v2 As Integer
        v1 = ComboBox491.SelectedItem
        value2 = ComboBox492.SelectedItem
        If Not String.IsNullOrEmpty(value2) And Not String.IsNullOrEmpty(v1) Then
            If value2.Equals("/") Then
                v2 = 10 - v1
            Else
                v2 = CInt(value2)
            End If
            Calculate(TextBox49, TextBox48, TextBox47, 9, v1, v2, 0, 4)
            ComboBox4101.Enabled = True
        End If
    End Sub

    Private Sub ComboBox4101_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox4101.SelectedIndexChanged
        Dim value As String
        value = ComboBox4101.SelectedItem
        If Not String.IsNullOrEmpty(value) Then
            If value.Equals("X") Then
                ComboBox4102.Items.Clear()
                For i As Integer = 0 To 9 Step 1
                    ComboBox4102.Items.Add(i)
                Next
                ComboBox4102.Items.Add("X")
                ComboBox4102.Enabled = True
                ComboBox4103.Items.Clear()
                TextBox410.Text = ""
            Else
                ComboBox4102.Items.Clear()
                For i As Integer = 0 To (9 - value) Step 1
                    ComboBox4102.Items.Add(i)
                Next
                ComboBox4102.Items.Add("/")
                ComboBox4102.Enabled = True
                ComboBox4103.Items.Clear()
                TextBox410.Text = ""
            End If
        End If
    End Sub

    Private Sub ComboBox4102_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox4102.SelectedIndexChanged
        Dim value1 As String
        Dim value2 As String
        Dim v1 As Integer
        Dim v2 As Integer
        value1 = ComboBox4101.SelectedItem
        value2 = ComboBox4102.SelectedItem
        If Not String.IsNullOrEmpty(value1) And Not String.IsNullOrEmpty(value2) Then
            If value1.Equals("X") Then
                ComboBox4103.Enabled = True
                If Not value2.Equals("X") Then
                    ComboBox4103.Items.Clear()
                    For i As Integer = 0 To (9 - CInt(value2)) Step 1
                        ComboBox4103.Items.Add(i)
                    Next
                    ComboBox4103.Items.Add("/")
                Else
                    ComboBox4103.Items.Clear()
                    For i As Integer = 0 To 9 Step 1
                        ComboBox4103.Items.Add(i)
                    Next
                    ComboBox4103.Items.Add("X")
                End If
                TextBox410.Text = ""
            Else
                If value2.Equals("/") Then
                    ComboBox4103.Items.Clear()
                    For i As Integer = 0 To 9 Step 1
                        ComboBox4103.Items.Add(i)
                    Next
                    ComboBox4103.Items.Add("X")
                    ComboBox4103.Enabled = True
                    TextBox410.Text = ""
                Else
                    v1 = CInt(value1)
                    v2 = CInt(value2)
                    ComboBox1101.Enabled = False
                    ComboBox4103.Items.Clear()
                    Calculate(TextBox410, TextBox49, TextBox48, 10, v1, v2, 0, 4)
                End If
            End If
        End If
    End Sub

    Private Sub ComboBox4103_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox4103.SelectedIndexChanged
        Dim value1 As String
        Dim value2 As String
        Dim value3 As String
        Dim v1 As Integer
        Dim v2 As Integer
        Dim v3 As Integer
        value1 = ComboBox4101.SelectedItem
        value2 = ComboBox4102.SelectedItem
        value3 = ComboBox4103.SelectedItem
        If Not String.IsNullOrEmpty(value1) And Not String.IsNullOrEmpty(value2) And Not String.IsNullOrEmpty(value3) Then
            If value1.Equals("X") Then
                v1 = 10
            Else
                v1 = CInt(value1)
            End If

            If value2.Equals("X") Then
                v2 = 10
            ElseIf value2.Equals("/") Then
                v2 = 10 - v1
            Else
                v2 = CInt(value2)
            End If

            If value3.Equals("X") Then
                v3 = 10
            ElseIf value3.Equals("/") Then
                v3 = 10 - v2
            Else
                v3 = CInt(value3)
            End If

            Calculate(TextBox410, TextBox49, TextBox48, 10, v1, v2, v3, 4)
        End If
    End Sub

    'this is the final piece of the puzzle. There is a clear button that just resets the page and clears
    'out all frame values and spare or strike flags.
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Name1.Text = "Enter Name"
        Name2.Text = "Enter Name"
        Name3.Text = "Enter Name"
        Name4.Text = "Enter Name"

        TextBox11.Text = ""
        TextBox12.Text = ""
        TextBox13.Text = ""
        TextBox14.Text = ""
        TextBox15.Text = ""
        TextBox16.Text = ""
        TextBox17.Text = ""
        TextBox18.Text = ""
        TextBox19.Text = ""
        TextBox110.Text = ""

        TextBox21.Text = ""
        TextBox22.Text = ""
        TextBox23.Text = ""
        TextBox24.Text = ""
        TextBox25.Text = ""
        TextBox26.Text = ""
        TextBox27.Text = ""
        TextBox28.Text = ""
        TextBox29.Text = ""
        TextBox210.Text = ""

        TextBox31.Text = ""
        TextBox32.Text = ""
        TextBox33.Text = ""
        TextBox34.Text = ""
        TextBox35.Text = ""
        TextBox36.Text = ""
        TextBox37.Text = ""
        TextBox38.Text = ""
        TextBox39.Text = ""
        TextBox310.Text = ""

        TextBox41.Text = ""
        TextBox42.Text = ""
        TextBox43.Text = ""
        TextBox44.Text = ""
        TextBox45.Text = ""
        TextBox46.Text = ""
        TextBox47.Text = ""
        TextBox48.Text = ""
        TextBox49.Text = ""
        TextBox410.Text = ""

        ComboBox111.SelectedIndex = -1
        ComboBox112.SelectedIndex = -1
        ComboBox121.SelectedIndex = -1
        ComboBox122.SelectedIndex = -1
        ComboBox131.SelectedIndex = -1
        ComboBox132.SelectedIndex = -1
        ComboBox141.SelectedIndex = -1
        ComboBox142.SelectedIndex = -1
        ComboBox151.SelectedIndex = -1
        ComboBox152.SelectedIndex = -1
        ComboBox161.SelectedIndex = -1
        ComboBox162.SelectedIndex = -1
        ComboBox171.SelectedIndex = -1
        ComboBox172.SelectedIndex = -1
        ComboBox181.SelectedIndex = -1
        ComboBox182.SelectedIndex = -1
        ComboBox191.SelectedIndex = -1
        ComboBox192.SelectedIndex = -1
        ComboBox1101.SelectedIndex = -1
        ComboBox1102.SelectedIndex = -1
        ComboBox1103.SelectedIndex = -1

        ComboBox211.SelectedIndex = -1
        ComboBox212.SelectedIndex = -1
        ComboBox221.SelectedIndex = -1
        ComboBox222.SelectedIndex = -1
        ComboBox231.SelectedIndex = -1
        ComboBox232.SelectedIndex = -1
        ComboBox241.SelectedIndex = -1
        ComboBox242.SelectedIndex = -1
        ComboBox251.SelectedIndex = -1
        ComboBox252.SelectedIndex = -1
        ComboBox261.SelectedIndex = -1
        ComboBox262.SelectedIndex = -1
        ComboBox271.SelectedIndex = -1
        ComboBox272.SelectedIndex = -1
        ComboBox281.SelectedIndex = -1
        ComboBox282.SelectedIndex = -1
        ComboBox291.SelectedIndex = -1
        ComboBox292.SelectedIndex = -1
        ComboBox2101.SelectedIndex = -1
        ComboBox2102.SelectedIndex = -1
        ComboBox2103.SelectedIndex = -1

        ComboBox311.SelectedIndex = -1
        ComboBox312.SelectedIndex = -1
        ComboBox321.SelectedIndex = -1
        ComboBox322.SelectedIndex = -1
        ComboBox331.SelectedIndex = -1
        ComboBox332.SelectedIndex = -1
        ComboBox341.SelectedIndex = -1
        ComboBox342.SelectedIndex = -1
        ComboBox351.SelectedIndex = -1
        ComboBox352.SelectedIndex = -1
        ComboBox361.SelectedIndex = -1
        ComboBox362.SelectedIndex = -1
        ComboBox371.SelectedIndex = -1
        ComboBox372.SelectedIndex = -1
        ComboBox381.SelectedIndex = -1
        ComboBox382.SelectedIndex = -1
        ComboBox391.SelectedIndex = -1
        ComboBox392.SelectedIndex = -1
        ComboBox3101.SelectedIndex = -1
        ComboBox3102.SelectedIndex = -1
        ComboBox3103.SelectedIndex = -1

        ComboBox411.SelectedIndex = -1
        ComboBox412.SelectedIndex = -1
        ComboBox421.SelectedIndex = -1
        ComboBox422.SelectedIndex = -1
        ComboBox431.SelectedIndex = -1
        ComboBox432.SelectedIndex = -1
        ComboBox441.SelectedIndex = -1
        ComboBox442.SelectedIndex = -1
        ComboBox451.SelectedIndex = -1
        ComboBox452.SelectedIndex = -1
        ComboBox461.SelectedIndex = -1
        ComboBox462.SelectedIndex = -1
        ComboBox471.SelectedIndex = -1
        ComboBox472.SelectedIndex = -1
        ComboBox481.SelectedIndex = -1
        ComboBox482.SelectedIndex = -1
        ComboBox491.SelectedIndex = -1
        ComboBox492.SelectedIndex = -1
        ComboBox4101.SelectedIndex = -1
        ComboBox4102.SelectedIndex = -1
        ComboBox4103.SelectedIndex = -1

        ComboBox112.Enabled = False
        ComboBox121.Enabled = False
        ComboBox122.Enabled = False
        ComboBox131.Enabled = False
        ComboBox132.Enabled = False
        ComboBox141.Enabled = False
        ComboBox142.Enabled = False
        ComboBox151.Enabled = False
        ComboBox152.Enabled = False
        ComboBox161.Enabled = False
        ComboBox162.Enabled = False
        ComboBox171.Enabled = False
        ComboBox172.Enabled = False
        ComboBox181.Enabled = False
        ComboBox182.Enabled = False
        ComboBox191.Enabled = False
        ComboBox192.Enabled = False
        ComboBox1101.Enabled = False
        ComboBox1102.Enabled = False
        ComboBox1103.Enabled = False

        ComboBox212.Enabled = False
        ComboBox221.Enabled = False
        ComboBox222.Enabled = False
        ComboBox231.Enabled = False
        ComboBox232.Enabled = False
        ComboBox241.Enabled = False
        ComboBox242.Enabled = False
        ComboBox251.Enabled = False
        ComboBox252.Enabled = False
        ComboBox261.Enabled = False
        ComboBox262.Enabled = False
        ComboBox271.Enabled = False
        ComboBox272.Enabled = False
        ComboBox281.Enabled = False
        ComboBox282.Enabled = False
        ComboBox291.Enabled = False
        ComboBox292.Enabled = False
        ComboBox2101.Enabled = False
        ComboBox2102.Enabled = False
        ComboBox2103.Enabled = False

        ComboBox312.Enabled = False
        ComboBox321.Enabled = False
        ComboBox322.Enabled = False
        ComboBox331.Enabled = False
        ComboBox332.Enabled = False
        ComboBox341.Enabled = False
        ComboBox342.Enabled = False
        ComboBox351.Enabled = False
        ComboBox352.Enabled = False
        ComboBox361.Enabled = False
        ComboBox362.Enabled = False
        ComboBox371.Enabled = False
        ComboBox372.Enabled = False
        ComboBox381.Enabled = False
        ComboBox382.Enabled = False
        ComboBox391.Enabled = False
        ComboBox392.Enabled = False
        ComboBox3101.Enabled = False
        ComboBox3102.Enabled = False
        ComboBox3103.Enabled = False

        ComboBox412.Enabled = False
        ComboBox421.Enabled = False
        ComboBox422.Enabled = False
        ComboBox431.Enabled = False
        ComboBox432.Enabled = False
        ComboBox441.Enabled = False
        ComboBox442.Enabled = False
        ComboBox451.Enabled = False
        ComboBox452.Enabled = False
        ComboBox461.Enabled = False
        ComboBox462.Enabled = False
        ComboBox471.Enabled = False
        ComboBox472.Enabled = False
        ComboBox481.Enabled = False
        ComboBox482.Enabled = False
        ComboBox491.Enabled = False
        ComboBox492.Enabled = False
        ComboBox4101.Enabled = False
        ComboBox4102.Enabled = False
        ComboBox4103.Enabled = False

        For i As Integer = 0 To 10 Step 1
            framevalues1(i) = 0
            framevalues2(i) = 0
            framevalues3(i) = 0
            framevalues4(i) = 0
        Next

        strikes1.Clear()
        strikes2.Clear()
        strikes3.Clear()
        strikes4.Clear()
        spares1.Clear()
        spares2.Clear()
        spares3.Clear()
        spares4.Clear()

    End Sub
End Class
