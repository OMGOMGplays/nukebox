using Sandbox;
using Sandbox.UI;
using Sandbox.UI.Construct;
using Sandbox.UI.Tests;
using System.Linq;
using BombProp = Nukebox.bombs.@base.BombProp;

[Library]
public partial class BombList : Panel 
{
	VirtualScrollPanel Canvas;

	public BombList() 
	{
		AddClass("spawnpage");
		AddChild(out Canvas, "canvas");

		Canvas.Layout.AutoColumns = true;
		Canvas.Layout.ItemWidth = 100;
		Canvas.Layout.ItemHeight = 100;
		Canvas.OnCreateCell = (cell, data) => 
		{
			if (data is BombProp type) 
			{
				var btn = cell.Add.Button(type.ClassName);
				btn.AddClass("icon");
				btn.AddEventListener("onclick", () => ConsoleSystem.Run("spawn_entity", type.ClassName));
				btn.Style.BackgroundImage = Texture.Load(FileSystem.Mounted, $"entity/{type.ClassName}.png", false);
			}
		};

		var ents = TypeLibrary.GetDescriptions<BombProp>()
									.Where(x => x.HasTag("spawnable"))
									.OrderBy(x => x.Title)
									.ToArray();

		foreach (var entry in ents)
		{
			Canvas.AddItem(entry);
		}
	}
}
