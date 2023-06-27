using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoProj2
{
    class Node
    {
        public int Data;
        public Node LC;
        public Node RC;
        public Node Parent;
        public Node(int d=0)
        {
            Data = d;
            LC = null;
            RC = null;
            Parent = null;
        }
        public Node(int d, Node r, Node l,Node p)
        {
            Data = d;
            RC = r;
            LC = l;
            Parent = p;
        }
    }
}
