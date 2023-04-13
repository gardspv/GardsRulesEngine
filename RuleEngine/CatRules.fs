module RuleEngine.CatRules

open RuleEngine

let catRules =
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

let checkBusinessObject businessObject =
    checkRulesForBusinessObject catRules businessObject
