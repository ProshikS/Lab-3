let NaturalNumbers n = //Генератор последовательности с числами
    seq{
        for i in 1 .. n do
            printf "Введите натуральное число: "
            let num = int(System.Console.ReadLine())
            if num < 0 then //проверка на корректность
                printfn "Введено неверное число!"
                printfn "Взято число по модулю!"
                yield abs(num)
            else
                if num = 0 then
                    printfn "Введено неверное число!"
                    printfn "Взято число 1"
                    yield 1
                else
                    yield num
    }

let rec Sum number = //функция вычисления суммы цифр числа
    if number = 0 then 
        0
    else 
        number % 10 + Sum (number/10)

[<EntryPoint>]
let main argv =
    printf "Введите количество элементов: "
    let length = int(System.Console.ReadLine())
    if length > 0 then
        let numbers = NaturalNumbers(length)
        let sumSeq = numbers |> Seq.map Sum |> Seq.toList
        printfn "Суммы цифр введенных чисел: "
        for s in sumSeq do
            printf "%d " s
    else 
        printfn "Введено неверное значение!"
    0