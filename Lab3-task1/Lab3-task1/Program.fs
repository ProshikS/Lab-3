open System

let rec naturalNumbers n = 
    seq{
        for i in 1 .. n do 
            printf "Введите натуральное число: "
            let str = System.Console.ReadLine()
            let succes, num = Int32.TryParse(str)
            if succes then
                yield abs(num)
            else
                printfn "Ошибка ввода!"
                yield! naturalNumbers 1
    }

let rec readNumber () =
    printf "Введите количество элементов: "
    let length = System.Console.ReadLine()
    let succes, number = Int32.TryParse(length)
    if succes then
        number
    else
        printfn "Ошибка ввода!"
        readNumber ()

let rec sum number = //функция вычисления суммы цифр числа
    if number = 0 then 
        0
    else 
        (number % 10) + sum (number/10)

[<EntryPoint>]
let main argv =
    let length = readNumber()
    let numbers = naturalNumbers(length)
    let sumSeq = numbers |> Seq.map sum 
    printfn "Суммы цифр введенных чисел: %A"sumSeq
    0