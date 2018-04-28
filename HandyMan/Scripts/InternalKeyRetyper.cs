
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace HandyMan.Scripts
{
    public static class InternalKeyRetyper
    {
        public static void ConvertKey(Dictionary<char, char> dic, char keyPressed)
        {

            /*Keyboard.FocusedElement.RaiseEvent(
                new KeyEventArgs( 
                    Keyboard.PrimaryDevice,
                    Keyboard.PrimaryDevice.ActiveSource,
                    0,
                    (Key)dic[keyPressed])
                { RoutedEvent = Keyboard.KeyDownEvent });*/




            TextBox target = (TextBox)Keyboard.FocusedElement;
            int cursorPosition = target.SelectionStart;
            target.Text = target.Text.Insert(cursorPosition, dic[keyPressed].ToString());
            target.SelectionStart = cursorPosition + 1;

            /*DebugPopup popup = new DebugPopup(dic[keyPressed] + " " + (Key)dic[keyPressed]);
            popup.Show();*/

        }
    }
}