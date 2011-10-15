using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace HtmlToBBCode
{
    public class HtmlToBBCode
    {
        private Dictionary<PatternKind, string> patterns;
        private PatternKind actualPattern;

        public HtmlToBBCode()
        {
            var paragraphPattern = @"<p>(?'conteudo'.+)</p>";
            var anchorPattern = "<a[\\w\\s]*href=\"(?'link'[\\w\\s\\/\\:\\.\\-]*)\"[\\w\\s\\\"\\=\\-]*>(?'conteudo'[\\w\\s\\[\\]\\/\\:\\.\\-]*)</a>";                                 
            var imagePattern = "<img[\\w\\s=\"-]*src=\"(?'link'[\\w\\s\\/\\:\\.\\-]*)\"[\\w\\s=\"-]*[/>|>]";
            var boldPattern = @"<strong>(?'conteudo'[\w\s\/\:\.\-]*)</strong>";
            var spacePattern = @"&nbsp";

            patterns = new Dictionary<PatternKind, string>
            {                
                { PatternKind.Space, spacePattern},
                { PatternKind.Bold, boldPattern },
                { PatternKind.Image, imagePattern },
                { PatternKind.Anchor, anchorPattern },
                { PatternKind.Paragraph, paragraphPattern }
            };
        }

        public string Convert(string html)
        {
            foreach (var pattern in patterns)
            {
                actualPattern = pattern.Key;
                Regex regex = new Regex(pattern.Value, RegexOptions.IgnoreCase);
                switch (actualPattern)
                {
                    case PatternKind.Space: html = regex.Replace(html, SpaceReplacer); break;
                    case PatternKind.Bold: html = regex.Replace(html, BoldReplacer); break;
                    case PatternKind.Image: html = regex.Replace(html, ImageReplacer); break;
                    case PatternKind.Anchor: html = regex.Replace(html, AnchorReplacer); break;
                    case PatternKind.Paragraph: html = regex.Replace(html, ParagraphReplacer); break;
                    default: break;
                }
            }
            return html;
        }

        private string SpaceReplacer(Match match)
        {
            return " ";
        }

        private string BoldReplacer(Match match)
        {
            return string.Format("[b]{0}[/b]", match.Groups["conteudo"].Value);
        }

        private string AnchorReplacer(Match match)
        {
            return string.Format("[url={0}]{1}[/url]", match.Groups["link"].Value, match.Groups["conteudo"].Value);
        }

        private string ImageReplacer(Match match)
        {
            return string.Format("[center][img]{0}[/img][/center]", match.Groups["link"].Value);
        }

        private string ParagraphReplacer(Match match)
        {
            return match.Groups["conteudo"].Value;
        }
    }
}
