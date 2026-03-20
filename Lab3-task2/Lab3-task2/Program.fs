let firstNum number dig = //функция определения первой цифры
    if (string(abs(number)).[0] = string(dig).[0]) then
        number
    else
        0.0

let inputAmount () = //ввод количества
    printf "Введите количество элементов: "
    let amount = int(System.Console.ReadLine())
    if (amount < 0) then //проверка корректности ввода
        printfn "Введено неправильное значение"
        -1 //флаг для обозначения неправильного ввода
    else
        amount

let inputNumber amount = //генератор seq с элементами
    seq{
    for i in 1 .. amount do
        printf "Введите число: "
        let number = float(System.Console.ReadLine())
        yield number
    }

let inputDig () =
    printf "Введите цифру: "
    let dig = int(System.Console.ReadLine())
    if (dig < 0 || dig > 9) then //проверка корректности ввода
        printfn "Введено неверное значение!"
        -1 //флаг для обозначения неправильного ввода
    else  
        dig

[<EntryPoint>]
let main avrg =
    let amount = inputAmount()
    if amount <> -1 then
        let n = inputNumber(amount)
        let dig = inputDig()
        if dig <> -1 then //проверка на флаги
            let sum=Seq.fold(fun ac e->ac+firstNum e dig)0.0 n
            printf "Сумма чисел равна %f" sum
            0
        else
        0
    else
    0