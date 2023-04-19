module RuleEngine.Main

open RuleEngine

"""
let testRuleEngineForBusinessObject =
    let businessObject =
        { Value = 16
          YearlyIncome = 500
          Country = "SE" }

    let businessRules =
        [ { Description = "Value not too high"
            RedLightRule =
              Some(
                  { Reason = "Value > 20"
                    Rule = (fun x -> x.Value > 20) }
              )
            YellowLightRule =
              Some(
                  { Reason = "Value > 15"
                    Rule = (fun x -> x.Value > 15) }
              ) }
          { Description = "Yearly income not too high"
            RedLightRule = None
            YellowLightRule =
              Some(
                  { Reason = "Yearly income > 300"
                    Rule = (fun x -> x.YearlyIncome > 300) }
              ) } ]

    let resultList = checkRulesForBusinessObject businessRules businessObject
    printfn "%A" resultList

let testRuleEngineForCat =
    let cat =
        { Color = "Grey"
          Weight = 17.1
          Age = 11 }

    let businessRules =
        [ { Description = "Cat must not be too old"
            RedLightRule =
              Some(
                  { Reason = "Value > 10"
                    Rule = (fun x -> x.Age > 10) }
              )
            YellowLightRule =
              Some(
                  { Reason = "Value > 6"
                    Rule = (fun x -> x.Age > 6) }
              ) }
          { Description = "Cat must not be black"
            RedLightRule =
              Some(
                  { Reason = "Cat is black"
                    Rule = (fun x -> x.Color.Equals("Black")) }
              )
            YellowLightRule = None } ]

    let resultList = checkRulesForBusinessObject businessRules cat
    printfn "%A" resultList
"""

[<EntryPoint>]
let main args =
    //testRuleEngineForBusinessObject
    //testRuleEngineForCat
    0
