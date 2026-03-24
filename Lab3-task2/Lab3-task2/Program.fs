open System

let firstNum number dig = //функция определения первой цифры
    if (string(abs(number)).[0] = string(dig).[0]) then
        number
    else
        0.0

let rec readNumber () =
    printf "Введите количество элементов: "
    let length = Console.ReadLine()
    let succes, number = Int32.TryParse(length)
    if succes && number>0 then
        number
    else
        printfn "Ошибка ввода!"
        readNumber ()

let rec inputNumber n = 
    seq{
        for i in 1 .. n do 
            printf "Введите число: "
            let str = Console.ReadLine()
            let succes, num = Double.TryParse(str)
            if succes then
                yield num
            else
                printfn "Ошибка ввода!"
                yield! inputNumber 1
    }

let rec inputDig () =
    printf "Введите цифру: "
    let str = Console.ReadLine()
    let succes, dig = Int32.TryParse(str)
    if succes then
        if (dig < 0 || dig > 9) then //проверка корректности ввода
            printfn "Введено неверное значение!"
            inputDig()
        else  
            dig
    else
        printfn "Ввведено неверное значение!"
        inputDig()
        

[<EntryPoint>]
let main avrg =
    let amount = readNumber()
    let n = inputNumber(amount)
    let dig = inputDig()
    let sum=Seq.fold(fun ac e->ac+firstNum e dig)0.0 n
    printf "Сумма чисел равна %f" sum
    0