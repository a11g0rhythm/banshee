/***************************************************************************
 *  Literals.cs
 *
 *  Copyright (C) 2007 Novell, Inc.
 *  Written by Aaron Bockover <abockover@novell.com>
 ****************************************************************************/

/*  THIS FILE IS LICENSED UNDER THE MIT LICENSE AS OUTLINED IMMEDIATELY BELOW: 
 *
 *  Permission is hereby granted, free of charge, to any person obtaining a
 *  copy of this software and associated documentation files (the "Software"),  
 *  to deal in the Software without restriction, including without limitation  
 *  the rights to use, copy, modify, merge, publish, distribute, sublicense,  
 *  and/or sell copies of the Software, and to permit persons to whom the  
 *  Software is furnished to do so, subject to the following conditions:
 *
 *  The above copyright notice and this permission notice shall be included in 
 *  all copies or substantial portions of the Software.
 *
 *  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR 
 *  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, 
 *  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE 
 *  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER 
 *  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING 
 *  FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER 
 *  DEALINGS IN THE SOFTWARE.
 */

using System;

namespace SExpEngine
{
    public class LiteralNodeBase : TreeNode
    {    
        private Type type = null;
        
        public Type EnclosedType {
            get { return type ?? GetType(); }
            protected set { type = value; }
        }
    }

    public class LiteralNode<T> : LiteralNodeBase
    {
        private T value;
        
        public LiteralNode(T value)
        {
            this.value = value;
            EnclosedType = typeof(T);
        }
        
        public override string ToString()
        {
            return Value.ToString();
        }
        
        public T Value {
            get { return value; }
        }
    }

    // Literal Types

    public class VoidLiteral : LiteralNodeBase
    {
        public override string ToString()
        {
            return "void";
        }
    }
    
    public class DoubleLiteral : LiteralNode<double>
    {
        public DoubleLiteral(double value) : base(value)
        {
        }
    }

    public class BooleanLiteral : LiteralNode<bool>
    {
        public BooleanLiteral(bool value) : base(value)
        {
        }
        
        public override string ToString()
        {
            return Value ? "true" : "false";
        }
    }

    public class IntLiteral : LiteralNode<int>
    {
        public IntLiteral(int value) : base(value)
        {
        }
    }

    public class StringLiteral : LiteralNode<string>
    {
        public StringLiteral(string value) : base(value)
        {
        }
    }
}
