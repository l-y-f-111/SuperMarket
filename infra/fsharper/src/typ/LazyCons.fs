namespace fsharper.typ

///惰性求值序对
module LazyCons =

    open System
    open fsharper.op.Lazy
    open fsharper.op.Reflect

    type LazyCons<'a> =
        | LazyNil
        | LazyCons of car: 'a * cdr: Lazy<LazyCons<'a>>

    let rec append ca cb =
        match ca, cb with
        | LazyNil, _ -> cb
        | _, LazyNil -> ca
        | LazyCons (x, xs), _ -> LazyCons(x, lazy (append (force xs) cb))

    let rec foldl f acc cons =
        match cons with
        | LazyCons (x, xs) -> foldl f (f acc x) (force xs)
        | LazyNil -> acc

    let rec foldr f acc cons =
        match cons with
        | LazyCons (x, xs) -> f x (foldr f acc (force xs))
        | LazyNil -> acc

    let inline concat cons = foldl append LazyNil cons

    type LazyCons<'a> with
        //Functor
        member self.fmap f =
            match self with
            | LazyCons (x, xs) -> LazyCons(f x, lazy ((force xs).fmap f))
            | LazyNil -> LazyNil

        //Applicative
        static member inline ap(ma: LazyCons<'x -> 'y>, mb: LazyCons<'x>) =
            let rec ap ma mb =
                match ma, mb with
                | LazyNil, _ -> LazyNil
                | _, LazyNil -> LazyNil
                | LazyCons (f, fs), LazyCons (x, xs) -> LazyCons(f x, lazy (ap (force fs) (force xs)))

            ap ma mb

        //Monad
        member inline self.bind f = self.fmap f |> concat

    type LazyCons<'a> with
        //Semigroup
        member self.mappend(mb: LazyCons<'a>) =
            match self, mb with
            | LazyNil, _ -> mb
            | _, LazyNil -> self
            | LazyCons (x, xs), _ -> LazyCons(x, lazy ((force xs).mappend mb))

        //Monoid
        static member mempty() = LazyNil

    type LazyCons<'t> with
        //Boxing
        static member inline wrap x = LazyCons(x, lazy (LazyNil))

        member self.unwrap() =
            match self with
            | LazyNil -> failwith "Try to unwrap LazyNil"
            | LazyCons (x, _) -> x


        member self.debug() =
            let f x acc =
                let msg =
                    try //下一级调试信息
                        x.tryInvoke "debug"
                    with
                    | _ -> x.ToString()

                $"{acc} {msg}"

            let result = foldl f "" self

            //去除首部空格
            $"({result.Remove(0, 1)})"

        static member list<'t>([<ParamArray>] arr: 't array) =
            let max = arr.Length - 1

            let rec withCount count =
                match count with
                | i when i = max -> LazyNil
                | i -> LazyCons(arr.[i], lazy (withCount (count + 1)))

            withCount 0

    [<AutoOpen>]
    module fn =

        let car c =
            match c with
            | LazyCons (x, _) -> x
            | LazyNil -> failwith "LazyCons is LazyNil"

        let cdr c =
            match c with
            | LazyCons (_, x) -> force x
            | LazyNil -> failwith "LazyCons is LazyNil"

        let cadr x = car <| cdr x

        let cdar x = cdr <| car x
