module RuleEngine.CatRules

open RuleEngine

let catRules =
    [ { Description = "Cat must not be too old";
        Rules=[LabelledRule.Red({
                Criteria = "Value > 10"
                Rule = (fun x -> x.Age > 10) });
        LabelledRule.Yellow(
              { Criteria = "Value > 6"
                Rule = (fun x -> x.Age > 6) })]
          };
      { Description = "Cat must not be black";
        Rules=[
          LabelledRule.Red(
              { Criteria = "Cat is black"
                Rule = (fun x -> x.Color.Equals("Black")) })
          ]}
      ]

let checkBusinessObject businessObject =
    checkRulesForBusinessObject catRules businessObject
