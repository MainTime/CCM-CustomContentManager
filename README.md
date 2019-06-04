# CCM-CustomContentManager
  Ist eine Bibliothek welche es einem ermöglicht Windows Forms Controls dynamisch zu speichern und zu laden.

# Unterstützte Controls
``` 
    Button
    Label
    PictureBox
    TextBox
    Panel
    CheckBox
    ListBox
    ComboBox
    RadioButton
    ProgressBar
    TreeView
    ListView
    LinkLabel
    NumericUpDown
    RichTextBox
```

# Beispiel
  ## C#
  Control Speichern:
  ```c#
      string compressedjson = new CCM_CustomContentManager.toJson().getJson(Panel1);
  ```
  Control Laden:
  ```c#
    this.Controls.Add(new CCM_CustomContentManager.toControl().getControl(compressedjson));
  ```
  ## VB.Net
  Control Speichern:
  ```vb.net
  Dim compressedjson As String = New CCM_CustomContentManager.toJson().getJson(Panel1)
  ```
  Control Laden:
  ```vb.net
  Me.Controls.Add(New CCM_CustomContentManager.toControl().getControl(compressedjson))
  ```
  
# Lizenz

<a rel="license" href="http://creativecommons.org/licenses/by-nc-nd/4.0/"><img alt="Creative Commons Lizenzvertrag" style="border-width:0" src="https://i.creativecommons.org/l/by-nc-nd/4.0/88x31.png" /></a><br /><span xmlns:dct="http://purl.org/dc/terms/" property="dct:title">CCM-CustomContentManager</span> von <a xmlns:cc="http://creativecommons.org/ns#" href="https://maintime.github.io/" property="cc:attributionName" rel="cc:attributionURL">MainTime</a> ist lizenziert unter einer <a rel="license" href="http://creativecommons.org/licenses/by-nc-nd/4.0/">Creative Commons Namensnennung - Nicht kommerziell - Keine Bearbeitungen 4.0 International Lizenz</a>.<br />Beruht auf dem Werk unter <a xmlns:dct="http://purl.org/dc/terms/" href="https://maintime.github.io/" rel="dct:source">https://maintime.github.io/</a>.<br />Über diese Lizenz hinausgehende Erlaubnisse können Sie unter <a xmlns:cc="http://creativecommons.org/ns#" href="https://maintime.github.io/" rel="cc:morePermissions">https://maintime.github.io/</a> erhalten.
