using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersembeOdevi
{
    public partial class Form1 : Form
    {
        public class Node
        {
            public int data;
            public Node next;
            public Node(int data)
            {
                this.data = data;
                this.next = null; // DÜZELTME: Kendi kendine atama (next = next) hatası düzeltildi, varsayılan olarak null atandı.
            }
        }

        public class bagliliste
        {
            public Node head;
            public Node tail;
            public bagliliste()
            {
                head = null;
                tail = null;
            }

            public int bastanCikar()
            {
                if (head == null)
                {
                    throw new Exception("Liste boş");
                }
                else
                {
                    int data = head.data;
                    head = head.next;
                    if (head == null)
                    {
                        tail = null; // Liste tamamen boşaldıysa tail'ı da sıfırla
                    }
                    return data;
                }
            }

            public void sonaEkle(int data)
            {
                Node eleman = new Node(data);
                if (head == null)
                {
                    head = tail = eleman;
                }
                else
                {
                    tail.next = eleman; // DÜZELTME: O(n) döngü maliyeti yerine elimizdeki 'tail' referansı kullanılarak doğrudan O(1) hızında sona ekleme sağlandı.
                    tail = eleman;
                }
            }
        }

        public class Stack
        {
            Node top;
            public Stack()
            {
                top = null;
            }

            public void push(int data)
            {
                Node eleman = new Node(data);
                if (top == null)
                {
                    top = eleman;
                }
                else
                {
                    eleman.next = top; // DÜZELTME: Stack mantığına göre yeni eleman eskisinin üstüne gelmeli ve onu göstermeli (LIFO)
                    top = eleman;
                }
            }

            public void pop()
            {
                if (top == null)
                {
                    return;
                }
                else
                {
                    int silinendeger = top.data;
                    top = top.next; // Üstteki elemanı düşür
                }
            }
        }

        public class Queue
        {
            bagliliste bagliliste1 = new bagliliste();

            public Node top()
            {
                return bagliliste1.head;
            }

            public void enQueue(int data)
            {
                bagliliste1.sonaEkle(data);
            }

            public void deQueue()
            {
                if (bagliliste1.head != null)
                {
                    bagliliste1.bastanCikar(); // DÜZELTME: Metodun başındaki çalışmayı engelleyen 'return;' satırı kaldırıldı.
                }
            }
        }

        public class Queue1
        {
            bagliliste bagliliste2 = new bagliliste();
            public Node top()
            {
                return bagliliste2.head;
            }
            public void enQueue(int data)
            {
                bagliliste2.sonaEkle(data);
            }
            public void deQueue()
            {
                if (bagliliste2.head != null)
                {
                    bagliliste2.bastanCikar();
                }
            }
        }

        public class Queue2
        {
            bagliliste bagliliste3 = new bagliliste();
            public Node top()
            {
                return bagliliste3.head;
            }
            public void enQueue(int data)
            {
                bagliliste3.sonaEkle(data);
            }
            public void deQueue()
            {
                if (bagliliste3.head != null)
                {
                    bagliliste3.bastanCikar();
                }
            }
        }

        Queue kuyruk = new Queue();
        Queue1 kuyruk1 = new Queue1(); // DÜZELTME: Nesne tipleri kendi sınıflarıyla eşleştirildi.
        Queue2 kuyruk2 = new Queue2();
        Random random = new Random();

        private void UpdateTextBox()
        {
            StringBuilder sb = new StringBuilder();

            Node current = kuyruk2.top();
            while (current != null)
            {
                sb.AppendLine("P3:" + current.data.ToString());
                current = current.next;
            }

            Node current1 = kuyruk1.top();
            while (current1 != null)
            {
                sb.AppendLine("P2:" + current1.data.ToString());
                current1 = current1.next;
            }

            Node current2 = kuyruk.top();
            while (current2 != null)
            {
                sb.AppendLine("P1:" + current2.data.ToString());
                current2 = current2.next;
            }

            textBox1.Text = sb.ToString();
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void listBox4_SelectedIndexChanged(object sender, EventArgs e) { }
        private void listBox5_SelectedIndexChanged(object sender, EventArgs e) { }
        private void listBox6_SelectedIndexChanged(object sender, EventArgs e) { }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e) { }
        private void listBox2_SelectedIndexChanged(object sender, EventArgs e) { }
        private void listBox3_SelectedIndexChanged(object sender, EventArgs e) { }

        private void button3_Click(object sender, EventArgs e)
        {
            // İhtiyaca göre checkBox tetikleme mantığı buraya kurulabilir.
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e) { }
        private void checkBox2_CheckedChanged(object sender, EventArgs e) { }
        private void checkBox3_CheckedChanged(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if (trackBar1.Value > 0)
            {
                timer1.Start();
                timer1.Enabled = true;
                timer1.Interval = 2400 - (trackBar1.Value * 200); // DÜZELTME: Atama güvenli hale getirildi.
            }
            else
            {
                timer1.Enabled = false;
                timer1.Stop();
            }
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            if (trackBar2.Value > 0)
            {
                timer5.Start();
                timer5.Enabled = true;
                timer5.Interval = 2400 - (trackBar2.Value * 200);
            }
            else
            {
                timer5.Enabled = false;
                timer5.Stop();
            }
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            if (trackBar3.Value > 0)
            {
                timer6.Start();
                timer6.Enabled = true;
                timer6.Interval = 2400 - (trackBar3.Value * 200);
            }
            else
            {
                timer6.Enabled = false;
                timer6.Stop();
            }
        }

        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            if (trackBar4.Value > 0)
            {
                timer7.Start();
                timer7.Enabled = true;
                timer7.Interval = 2400 - (trackBar4.Value * 200);
            }
            else
            {
                timer7.Enabled = false;
                timer7.Stop();
            }
        }

        private void Form1_Load(object sender, EventArgs e) { }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // İhtiyaca göre genel senkronizasyon mantığı buraya yazılabilir.
        }

        private void timer5_Tick(object sender, EventArgs e)
        {
            int randomsayi = random.Next(1, 7); // DÜZELTME: Sınıf seviyesindeki 'random' nesnesi ortak kullanıldı.
            kuyruk.enQueue(randomsayi);
            listBox4.Items.Add(randomsayi);

            if (checkBox1.Checked)
            {
                listBox1.Items.Add(randomsayi);
                kuyruk.deQueue();
            }
            UpdateTextBox();
        }

        private void timer6_Tick(object sender, EventArgs e)
        {
            int randomsayi1 = random.Next(1, 7);
            kuyruk1.enQueue(randomsayi1);
            listBox5.Items.Add(randomsayi1);

            if (checkBox2.Checked)
            {
                listBox2.Items.Add(randomsayi1);
                kuyruk1.deQueue();
            }
            UpdateTextBox();
        }

        private void timer7_Tick(object sender, EventArgs e)
        {
            int randomsayi2 = random.Next(1, 7);
            kuyruk2.enQueue(randomsayi2);
            listBox6.Items.Add(randomsayi2);

            if (checkBox3.Checked)
            {
                listBox3.Items.Add(randomsayi2);
                kuyruk2.deQueue();
            }
            UpdateTextBox();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Interval = 2400;
            timer5.Interval = 2400;
            timer6.Interval = 2400;
            timer7.Interval = 2400;

            timer1.Start();
            timer7.Start();
            timer6.Start();
            timer5.Start();
            UpdateTextBox();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            timer5.Stop();
            timer6.Stop();
            timer7.Stop();
        }
    }
}