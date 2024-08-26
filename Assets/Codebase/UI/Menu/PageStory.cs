using System.Collections.Generic;
using UnityEngine;

namespace Codebase.UI.Menu
{
    public class PageStory : MonoBehaviour
    {
        public MainMenuPage menu;
        public SettingsPage settings;

        private Stack<IPage> story = new();

        private void Start()
        {
            menu.Close();
            settings.Close();

		    Push(menu);
        }

        public void Push(IPage page)
        {
            if (story.TryPeek(out var peek))
            {
                peek.Close();
            }

            story.Push(page);
            story.Peek().Open();
        }

        public void Pop()
        {
		    if (story.TryPeek(out var peek))
		    {
			    peek.Close();
		    }

		    story.Pop();
		    story.Peek().Open();
	    }
    }
}