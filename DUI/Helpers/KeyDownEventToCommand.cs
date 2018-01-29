﻿using System.Windows.Input;
using DevExpress.Mvvm.UI;

namespace DUI.Helpers {
    public class KeyDownEventToCommand : EventToCommand {
        public Key Key { get; set; }

        protected override void OnEvent(object sender, object eventArgs) {
            KeyEventArgs keyEventArgs = eventArgs as KeyEventArgs;
            if(keyEventArgs != null && keyEventArgs.Key == Key)
                base.OnEvent(sender, eventArgs);
        }
    }
}
