using System;
using CsQuery;

namespace Rainy.NoteConversion
{
	public static class NoteConversion
	{
		public static string ToHtml (this string note_body)
		{
			var body = note_body.Replace ("\n", "<br>");
			CQ note = body;

			note["bold"].ReplaceOuterWithTag("<b/>");
			note["italic"].ReplaceOuterWithTag ("<i/>");
			note["list"].ReplaceOuterWithTag ("<ul/>");
			note["list-item"].ReplaceOuterWithTag ("<li/>");

			return note.Render ();
		}
		private static CQ ReplaceOuterWithTag (this CQ element, string tag)
		{
			element.Each (domobj => {
				CQ t = new CQ (tag);
				CQ o = new CQ (domobj);
				o.ReplaceOuterWith (t);
			});
			return element;
		}
		private static CQ ReplaceOuterWith (this CQ element, CQ new_outer)
		{
			element.WrapInner (new_outer);
			return element.ReplaceWith (element.Children ());
		}

		public static string ToTomboyXml (this string html_body)
		{
			var body = html_body.Replace ("<br>", "\n");
			CQ html = body;

			html["b"].ReplaceOuterWithTag("<bold/>");
			html["i"].ReplaceOuterWithTag ("<i/>");
			html["ul"].ReplaceOuterWithTag ("<list/>");
			html["li"].ReplaceOuterWithTag ("<list-item/>");

			return html.Render ();
		}
	}
}
