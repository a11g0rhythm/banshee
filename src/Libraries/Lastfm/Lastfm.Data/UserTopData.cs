//
// UserTopData.cs
//
// Authors:
//   Gabriel Burt <gburt@novell.com>
//
// Copyright (C) 2008 Novell, Inc.
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
//
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//

using System;

namespace Lastfm.Data
{
    public abstract class UserTopData<T> : UserData<T> where T : UserTopEntry
    {
        protected TopType type;
        public TopType Type {
            get { return type; }
        }

        public UserTopData (string username, string fragment, TopType type)
            : base (username, String.Format ("{0}?type={1}", fragment, TopTypeToParam (type)))
        {
            this.type = type;
        }
    }

    public abstract class UserTopEntry : DataEntry
    {
        public string Name              { get { return Get<string>   ("name"); } }
        public string MbId              { get { return Get<string>   ("mbid"); } }
        public int PlayCount            { get { return Get<int>      ("playcount"); } }
        public int Rank                 { get { return Get<int>      ("rank"); } }
        public string Url               { get { return Get<string>   ("url"); } }
    }
}
