
//Copyright 2019,2020 Jolan Aklin and Yohan Zbinden


//This file is part of FileTeleporter.

//FileTeleporter is free software: you can redistribute it and/or modify
//it under the terms of the GNU General Public License as published by
//the Free Software Foundation, version 3 of the License.

//FileTeleporter is distributed in the hope that it will be useful,
//but WITHOUT ANY WARRANTY; without even the implied warranty of
//MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//GNU General Public License for more details.

//You should have received a copy of the GNU General Public License
//along with FileTeleporter.  If not, see<https://www.gnu.org/licenses/>.


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Theming
{



    public static class Theme
    {
        private static bool white;
        public static Color backColor1;
        public static Color backColor2;
        public static Color hoverColor;
        //public static Color clickColor;
        public static Color textColor;

        public static void Initialize(bool whiteTheme)
        {
            white = whiteTheme;
            if (white)
            {
                backColor1 = Color.FromArgb(255, 255, 255, 255);
                backColor2 = Color.FromArgb(255, 230, 230, 230);
                hoverColor = Color.FromArgb(255, 65, 175, 245);
                //clickColor = Color.FromArgb(255, 60, 60, 65);
                textColor = Color.FromArgb(255, 0, 0, 0);
            }
            else
            {
                backColor1 = Color.FromArgb(255, 36, 36, 41);
                backColor2 = Color.FromArgb(255, 45, 45, 50);
                hoverColor = Color.FromArgb(255, 7, 114, 185);
                //clickColor = Color.FromArgb(255, 60, 60, 65);
                textColor = Color.FromArgb(255, 255, 255, 255);
            }
        }
    }
}
