//hàm sắp xếp (swap)
void swap(ref int x, ref int y)
{
    int temp = x;
    x = y;
    y = temp;
}
void create_array(int[] values)
{
    Random rd = new Random();
    for (int i = 0; i < values.Length; i++)
    {
        values[i] = rd.Next(100);
    }
}

void print_array(int[] values)
{
    foreach (int value in values)
        Console.Write($"{value} \t");
}

void sort_array(int[] arr)
{
    for (int i = 0; i < arr.Length; i++)
    {
        for (int j = 0; j < arr.Length; j++)
        {
            if (arr[i] > arr[j])
            {
                swap(ref arr[i], ref arr[j]);
            }
        }
    }
}
//Sort_arrayByDowhile
void sort_arrayByDowhile(int[] arr)
{
    int i = 0;
    do
    {
        do
        {
            int j = i + 1;
            if (arr[i] > arr[j])
            {
                swap(ref arr[i], ref arr[j]);
            }
            j++;
        } while (i < arr.Length);
        i++;
    } while (i < arr.Length - 1);
}
