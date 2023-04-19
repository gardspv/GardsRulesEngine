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

let rec checkRuleSet businessObject ruleSet =
    match ruleSet.Rules with
    | [] -> createRuleResult ruleSet.Description "OK" Green
    | head::tail ->
        match head with
        | Red rule ->
            if rule.Rule businessObject then createRuleResult ruleSet.Description rule.Criteria TrafficLight.Red
            else checkRuleSet businessObject {Description=ruleSet.Description; Rules=tail}
        | Yellow rule ->
            if rule.Rule businessObject then createRuleResult ruleSet.Description rule.Criteria TrafficLight.Yellow
            else checkRuleSet businessObject {Description=ruleSet.Description; Rules=tail}

let checkRulesForBusinessObject businessRules businessObject =
    List.map (checkRuleSet businessObject) businessRules
