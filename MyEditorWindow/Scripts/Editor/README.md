# Editor folder

Reserved for Editor scripts, which add functionality to the Unity Editor at authoring time but aren’t available in Player builds at runtime. 
An alternative to placing scripts in a folder called ``Editor`` is to create an [assembly definition asset for Editor code](https://docs.unity3d.com/6000.4/Documentation/Manual/assembly-definitions-creating.html). 
<br>
The exact location of an ``Editor`` folder determines the script compilation order of its contents. For more information, refer to [Special folders and script compilation order](https://docs.unity3d.com/6000.4/Documentation/Manual/script-compile-order-folders.html).

**Maximum number of folders with this name per project:** Unlimited 
<br>
**Valid location for folder:** Root of the ``Assets`` folder or any of its subfolders. 
<br>
**Place relevant assets in:** ``Editor`` folder or any of its subfolders. 


