using System;

namespace Indexers
{
	sealed class PhoneBook
	{
        private int used;
        private Name[] names;
        private PhoneNumber[] phoneNumbers;

		public PhoneBook()
		{
			int initialSize = 0;
			this.used = 0;
			this.names = new Name[initialSize];
			this.phoneNumbers = new PhoneNumber[initialSize];
		}
		
		public void Add(Name name, PhoneNumber number)
		{
			enlargeIfFull();
			this.names[used] = name;
			this.phoneNumbers[used] = number;
			this.used++;
		}
		
		public Name this[PhoneNumber number]
		{
			get
			{
				int i=Array.IndexOf(this.phoneNumbers,number); 
                /*
				 *该访问器的目的是查找与指定电话号码匹配的名称。为此，您需要调用 Array 类的静态 IndexOf 方法。
				 *IndexOf 方法会遍历一个数组并返回数组中第一个与指定值匹配的元素的索引。IndexOf 方法的第一个参
				 *数是要搜索的数组（phoneNumbers）。IndexOf 方法的第二个参数是要搜索的项。IndexOf 方法如果找
				 *到匹配项，则返回元素的整数索引；否则返回 -1。如果访问器找到了电话号码，它应该返回相应的名称；
				 *否则，它应该返回一个空的 Name 值。（注意，Name 是一个结构体，因此默认构造函数将其私有 name 字段
				 *设置为 null。）
				 */
                if (i != -1)			
				{
					return this.names[i];

				}
				else
				{
					return new Name();
				}
			}
		}

        public PhoneNumber this[Name name]
		{
            //请注意，PhoneNumber 是一个结构体，因此总是具有默认构造函数。
            /*
			 * 请注意，这些重载的索引器能够共存，因为它们所索引的值是不同类型的，
			 * 这意味着它们的签名是不同的。如果 Name 和 PhoneNumber 结构被替换
			 * 为简单的字符串（它们对其进行了封装），这些重载将具有相同的签名，那么
			 * 该类将无法编译。
			 */

            get
            {
				int i = Array.IndexOf(this.names,name);
				if (i != -1)
				{
					return this.phoneNumbers[i];
				}
				else
				{
					return new PhoneNumber();
				}
			}
		}

        private void enlargeIfFull()
		{
			if (this.used == this.names.Length)
			{
				int bigger = used + 16;
				
				Name[] moreNames = new Name[bigger];
				this.names.CopyTo(moreNames, 0);
				
				PhoneNumber[] morePhoneNumbers = new PhoneNumber[bigger];
				this.phoneNumbers.CopyTo(morePhoneNumbers, 0);
						
				this.names = moreNames;
				this.phoneNumbers = morePhoneNumbers;
			}
		}
	}
}