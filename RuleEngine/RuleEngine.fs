module RuleEngine.RuleEngine

type TrafficLight =
    | Red
    | Yellow
    | Green

type BusinessObject =
    { Value: int
      YearlyIncome: int
      Country: string }

type Cat =
    { Color: string
      Weight: double
      Age: int }

type Rule<'T> = { Criteria: string
                  Rule: 'T -> bool }

type LabelledRule<'T> =
    Red of Rule<'T>
    | Yellow of Rule<'T>

let trafficLightComparator x y =
    match x with
    | Red _ ->
        match y with
        | Yellow _ -> -1
        | Red _ -> 0
    | Yellow x ->
        match y with
        | Yellow _ -> 0
        | Red _ -> 1
    

type RuleSet<'T> =
    { Description: string
      Rules: List<LabelledRule<'T>> }

type RuleResult<'T> =
    { RuleDescription: string
      Light: TrafficLight
      CriteriaViolated: string
    }

let createRuleResult ruleSetDescription ruleCriteria light =
    { RuleDescription = ruleSetDescription
      Light = light
      CriteriaViolated = ruleCriteria }
    
//Iterere gjennom listen, avslutte om en regel brytes

let evaluate businessObject ruleSet =
    let sortedRuleSet = List.sortWith trafficLightComparator ruleSet
    
    if ruleSet.RedLightRule.IsSome && ruleSet.RedLightRule.Value.Rule businessObject then
        createRuleResult ruleSet.Description ruleSet.RedLightRule.Value.Reason Red
    elif ruleSet.YellowLightRule.IsSome && ruleSet.YellowLightRule.Value.Rule businessObject then
        createRuleResult ruleSet.Description ruleSet.YellowLightRule.Value.Reason Yellow
    else
        createRuleResult ruleSet.Description "OK" Green

let checkRulesForBusinessObject businessRules businessObject =
    List.map (evaluate businessObject) businessRules
