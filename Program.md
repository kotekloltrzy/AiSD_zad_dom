```c#
class HuffmanNode
{
    public char character { get; set; }
    public int freq { get; set; }
    public HuffmanNode left { get; set; }
    public HuffmanNode right { get; set; }

    public HuffmanNode(char character, int frequency)
    {
        this.character = character;
        freq = frequency;
        left = right = null;
    }

    public static Comparison<HuffmanNode> Compare = (x, y) => x.freq - y.freq;
}





class HuffmanTree
{
    public HuffmanNode BuildTree(string input)
    {
        var ilosci = input.GroupBy(c => c).ToDictionary(g => g.Key, g => g.Count());

       
        var queue = new List<HuffmanNode>();

        foreach (var item in ilosci)
        {
            queue.Add(new HuffmanNode(item.Key, item.Value));
        }

       
        queue.Sort(HuffmanNode.Compare);

       
        while (queue.Count > 1)
        {
          
            var left = queue[0];
            var right = queue[1];

        
            var newNode = new HuffmanNode('\0', left.freq + right.freq)
            {
                left = left,
                right = right
            };

            
            queue.RemoveAt(0);
            queue.RemoveAt(0);
            queue.Add(newNode);

            
            queue.Sort(HuffmanNode.Compare);
        }

       
        return queue[0];
    }
       



    public void Coder(HuffmanNode node, string kod, Dictionary<char, string> kody)
    {
        if (node == null)
            return;

        
        if (node.left == null && node.right == null)
        {
            kody[node.character] = kod;
        }

       
        Coder(node.left, kod + "0", kody);
        Coder(node.right, kod + "1", kody);
    }

    



    public string Encoder(string input, Dictionary<char, string> codes)
    {
        string encoded = string.Empty;
        foreach (var c in input)
        {
            encoded += codes[c];
        }
        return encoded;
    }




    public string Decoder(HuffmanNode root, string encoded)
    {
        string decoded = string.Empty;
        HuffmanNode current = root;
        foreach (var i in encoded)
        {
            current = (i == '0') ? current.left : current.right;


            if (current.left == null && current.right == null)
            {
                decoded += current.character;
                current = root;
            }
        }
        return decoded;
    }




}

class Program
{
    static void Main()
    {
        string input = "greatest estate developer";

        Console.WriteLine(input);

        var drzewo = new HuffmanTree();
        var root = drzewo.BuildTree(input);

        Dictionary<char, string> kody = new Dictionary<char, string>();
        drzewo.Coder(root, "", kody);

        Console.WriteLine("Kody- ");
        foreach (var i in kody)
        { 
            Console.WriteLine( i.Key + " " + i.Value);
        }

        string encoded = drzewo.Encoder(input, kody);
        Console.WriteLine("Zakodowany: " + encoded);

        string decoded = drzewo.Decoder(root, encoded);
        Console.WriteLine("Odkodowany: " + decoded);
    }
}
```
