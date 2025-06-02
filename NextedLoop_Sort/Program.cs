//hàm sắp xếp (swap)
void swap(ref int x, ref int  y)
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

void sort_arrayy(int [][] arr)
{
    int i = 0;
    do
    {
        int i = j = 1;
        if (arr[i] > arr[j])
            swap(arr[i], arr[j]);
    }
    while (arr[i] < arr[j]) {
        swap(arr[j], arr[i]);
    }
}