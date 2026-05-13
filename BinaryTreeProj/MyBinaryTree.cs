using System;
using System.Collections;
using System.Collections.Generic;
using BinaryTreeProj;

namespace MyBinaryTreeProj
{
    public class MyBinaryTree<T> : IEnumerable<T> where T : IComparable<T>
    {
        private MyBinaryTreeNode<T> _head;
        private int _count;

        public int Count => _count;

        public void Add(T value)
        {
            if (_head == null)
            {
                _head = new MyBinaryTreeNode<T>(value);
            }
            else
            {
                AddTo(_head, value);
            }
            _count++;
        }

        private void AddTo(MyBinaryTreeNode<T> node, T value)
        {
            if (value.CompareTo(node.Value) < 0)
            {
                if (node.Left == null) node.Left = new MyBinaryTreeNode<T>(value);
                else AddTo(node.Left, value);
            }
            else
            {
                if (node.Right == null) node.Right = new MyBinaryTreeNode<T>(value);
                else AddTo(node.Right, value);
            }
        }

        public bool Remove(T value)
        {
            // 1. ՓՆՏՐՈՒՄ ԵՆՔ ԹԻՎԸ
            MyBinaryTreeNode<T> current, parent;
            // Գտնում ենք հեռացվող հանգույցը (current) և նրա հորը (parent)
            current = FindWithParent(value, out parent);

            // Եթե FindWithParent-ը վերադարձրեց null, նշանակում է այդ թիվը ծառում չկա
            if (current == null) return false;

            // Եթե գտել ենք, ուրեմն հաստատ ջնջելու ենք, պակասեցնում ենք ընդհանուր քանակը
            _count--;

            // ---------------------------------------------------------
            // ԴԵՊՔ 1: ՀԵՌԱՑՎՈՂԸ ՉՈՒՆԻ ԱՋ ԶԱՎԱԿ (Right == null)
            // ---------------------------------------------------------
            if (current.Right == null)
            {
                // Եթե հեռացվողը Արմատն է (չունի հայր), ապա Արմատը դառնում է նրա ձախ զավակը
                if (parent == null) _head = current.Left;
                else
                {
                    // Եթե հեռացվողը իր հոր ձախ կողմում էր, հոր ձախին ենք միացնում հեռացվողի ձախը
                    if (parent.Left == current) parent.Left = current.Left;
                    // Եթե աջ կողմում էր, հոր աջին ենք միացնում հեռացվողի ձախը
                    else parent.Right = current.Left;
                }
            }
            // ---------------------------------------------------------
            // ԴԵՊՔ 2: ԱՋ ԶԱՎԱԿԸ ԿԱ, ԲԱՅՑ ԱՅԴ ԱՋԸ ՁԱԽ ԶԱՎԱԿ ՉՈՒՆԻ
            // ---------------------------------------------------------
            else if (current.Right.Left == null)
            {
                // Հեռացվողի աջ զավակին տալիս ենք հեռացվողի ձախ ճյուղը (որ չկորի)
                current.Right.Left = current.Left;

                // Եթե հեռացվողը Արմատն էր, Արմատը դառնում է հեռացվողի աջ զավակը
                if (parent == null) _head = current.Right;
                else
                {
                    // Հորը (parent) միացնում ենք հեռացվողի աջ զավակին
                    if (parent.Left == current) parent.Left = current.Right;
                    else parent.Right = current.Right;
                }
            }
            // ---------------------------------------------------------
            // ԴԵՊՔ 3: Հեռացվողն ունի երկու զավակ և խորը ճյուղեր
            // ---------------------------------------------------------
            else
            {
                // Փնտրում ենք աջ ենթածառի ամենափոքր տարրը (leftmost)
                // Դրա համար գնում ենք աջ, ու հետո անվերջ ձախ
                MyBinaryTreeNode<T> leftmost = current.Right.Left;
                MyBinaryTreeNode<T> leftmostParent = current.Right;

                // Քանի դեռ ձախ կողմում էլի թիվ կա, իջնում ենք ներքև
                while (leftmost.Left != null)
                {
                    leftmostParent = leftmost; // Պահում ենք ամենաձախի հորը
                    leftmost = leftmost.Left;   // Իջնում ենք ձախ
                }

                // leftmost-ին իր հին տեղից հանում ենք (իր հոր ձախին միացնում ենք իր աջը)
                leftmostParent.Left = leftmost.Right;

                // leftmost-ին տալիս ենք հեռացվողի (current) կապերը
                leftmost.Left = current.Left;   // leftmost-ի ձախը դառնում է ջնջվողի ձախը
                leftmost.Right = current.Right; // leftmost-ի աջը դառնում է ջնջվողի աջը

                // leftmost-ին միացնում ենք (parent-ին)
                if (parent == null) _head = leftmost; // Եթե ջնջվողը արմատն էր
                else
                {
                    // parent համապատասխան ճյուղին կպցնում ենք leftmost-ին
                    if (parent.Left == current) parent.Left = leftmost;
                    else parent.Right = leftmost;
                }
            }
            
            return true;
        }
        // Վերադարձնում է ամենափոքր արժեքը (T)
        public T GetMin()
        {
            if (_head == null)
                throw new InvalidOperationException("Ծառը դատարկ է:");

            MyBinaryTreeNode<T> current = _head;
            // Քանի դեռ ձախ կողմում էլի տարր կա, գնում ենք ձախ
            while (current.Left != null)
            {
                current = current.Left;
            }

            return current.Value;
        }

        // 1. Մեթոդը վերադարձնում է գտած հանգույցը (Node), 
        // իսկ 'out parent'-ի միջոցով հետ է տալիս նաև նրա հորը:
        private MyBinaryTreeNode<T> FindWithParent(T value, out MyBinaryTreeNode<T> parent)
        {
            // 2. Սկսում ենք որոնումը արմատից (_head)
            MyBinaryTreeNode<T> current = _head;

            // Սկզբում հայրը չկա, դրա համար null է
            parent = null;

            // 3. ՑԻԿԼ. Քանի դեռ չենք հասել ծառի ավարտին (null)
            while (current != null)
            {
                // Համեմատում ենք փնտրվող արժեքը ընթացիկ հանգույցի արժեքի հետ
                int result = value.CompareTo(current.Value);

                // 4. Եթե գտանք թիվը (result == 0)
                if (result == 0)
                    return current; // Վերադարձնում ենք գտած հանգույցը (parent-ն արդեն պահված է)

                // 5. Եթե դեռ չենք գտել, ապա ընթացիկ հանգույցը դառնում է «հայր» (parent)
                // քանի որ հաջորդ քայլին իջնելու ենք մի հարկ ներքև
                parent = current;

                // 6. Որոշում ենք ուղղությունը.
                if (result < 0)
                    // Եթե փնտրվող թիվը փոքր է՝ գնա ձախ
                    current = current.Left;
                else
                    // Եթե մեծ է՝ գնա աջ
                    current = current.Right;
            }

            // 7. Եթե ցիկլն ավարտվեց ու ոչինչ չգտանք, վերադարձնում ենք null
            return null;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return InOrder(_head).GetEnumerator();
        }

        private IEnumerable<T> InOrder(MyBinaryTreeNode<T> node)
        {
            if (node == null) yield break;
            // Ռեկուրսիվ գնա ձախ՝ մինչև ամենափոքր թիվը
            foreach (var n in InOrder(node.Left)) yield return n;
            // Վերադարձրու ընթացիկ հանգույցի արժեքը
            yield return node.Value;
            // Հետո նոր գնա աջ կողմի թվերի հետևից
            foreach (var n in InOrder(node.Right)) yield return n;
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}