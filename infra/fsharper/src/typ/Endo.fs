module fsharper.typ.Endo

//TODO exp feature

open fsharper.typ
open fsharper.op.Reflect

type Endo<'a> = Endo of appEndo: ('a -> 'a)

type Endo<'a> with
    //Semigroup
    member self.mappend(Endo b) =
        match self with
        | Endo a -> Endo(b >> a)

    //Monoid
    static member mempty: Endo<'a> = Endo id

let appEndo (Endo appEndo) = appEndo
