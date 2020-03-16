module Tests

open System
open Xunit
open Common.FEEL.Engine.Expression

[<Fact>]
let ``Create Ignore Statement`` () =
    let res = IgnoreStatement.create "r01"
    Assert.NotNull(res)
    match res with  
        | Error e -> failwith e
        | Ok stmt -> 
            Assert.NotNull stmt            
            Assert.Equal("r01",stmt.Id())

 
[<Fact>]
let ``Create Equals Statement`` () =
    let res = EqualsStatement.create "r02" "Car"
    Assert.NotNull (res)
    match res with  
        | Error e -> failwith e
        | Ok stmt -> 
            Assert.NotNull stmt
            Assert.Equal("r02",stmt.Id())   
            match stmt with
                | Equals e ->   Assert.Equal("Car",e.Right())
                | _ -> Assert.True(true)

    
