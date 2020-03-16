namespace Common.FEEL.Engine

open System
module Expression =
    type  IgnoreStatement = private {
        id : string
    }

    type EqualsStatement =
     private {
        id : string
        right : string
     }
     member self.Right() = self.right
     
    type  Statement =
        | Ignore of IgnoreStatement 
        | Equals of  EqualsStatement
        member self.Id() =
            match self with 
            | Ignore i -> i.id
            | Equals e -> e.id
    module IgnoreStatement =
        let create id  : Result<Statement,string>=
            match (id |>  String.IsNullOrWhiteSpace) with
              | true -> Error "Id cannot be empty"
              | _ -> Ignore  { id = id} |> Ok

    module EqualsStatement =
        let create id rightOperand  =
            match (id |>  String.IsNullOrWhiteSpace) with
              | true -> Error "Id cannot be empty"
              | _ -> Equals  {id = id; right = rightOperand} |> Ok
       

    
   
    
    
    
    type Expression = {
        statements : Statement seq
        inputs : string seq
        outputs : string seq
    }

    