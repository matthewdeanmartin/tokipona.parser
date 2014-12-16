using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using BasicTypes.Esperanto.Dictionary;
using NUnit.Framework;

namespace BasicTypes.Esperanto.Tokens
{
    [TestFixture]
    public class EoPartsTests
    {
        [Test]
        public void Test()
        {
            Type rootDictionary = typeof(RootDictionary); 
            
            Type affixDictionary = typeof(EoAffixes);
            MemberInfo[] roots= rootDictionary.GetFields();
            MemberInfo[] affixes = affixDictionary.GetFields();

            foreach (MemberInfo info in roots)
            {
                foreach (MemberInfo affixInfo in affixes)
                {
                    object rootObject = rootDictionary.InvokeMember(info.Name, BindingFlags.GetField, null, null, null);
                    object affixObject = affixDictionary.InvokeMember(affixInfo.Name, BindingFlags.GetField, null, null, null);

                    if (rootObject is EoRoot && affixObject is EoAffix)
                    {
                        EoRoot root = rootObject as EoRoot;
                        EoAffix affix = affixObject as EoAffix;
                        //EoWord w = new EoWord(root, 'o');
                        //Console.WriteLine(w);
                        EoWord w2 = new EoWord(new[] {root}, new[] {affix}, 'i');
                        Console.WriteLine(w2);
                    }
                }
            }
        }
    }
}
