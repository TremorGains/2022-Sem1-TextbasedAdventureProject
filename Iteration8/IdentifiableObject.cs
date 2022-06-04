using System;
using System.Collections.Generic;
using System.Text;

namespace SwinAdventure
{
    public class IdentifiableObject
    {
        private List<string> _identifiers = new List<string>();

        public IdentifiableObject(string[] idents)
        {
            for(int i = 0; i < idents.Length; i++)
            {
                _identifiers.Add(idents[i].ToLower());
            }
        }

        public bool AreYou(string id)
        {
            string name = id.ToLower();

            foreach (string j in _identifiers)
            {
                if (name == j)
                {
                    return true;
                }
            }


            return false;
        }

        public string FirstId
        {
            get
            {
                return _identifiers[0];
            }
        }

        public void AddIdentifier(string id)
        {
            _identifiers.Add(id.ToLower());
        }
    }
}
