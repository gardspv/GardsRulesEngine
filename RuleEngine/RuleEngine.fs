module RuleEngine.RuleEngine

type TrafficLight = Red | Yellow | Green

type BusinessObject = {Value: int
                       YearlyIncome: int
                       Country: string}

type Cat = {Color: string
            Weight: double
            Age: int}

type Rule<'T> = {Reason: string;
                 Rule: ('T -> bool)}

type RuleSet<'T> = {Description: string;
                RedLightRule: Rule<'T> option;
                YellowLightRule: Rule<'T> option}

type RuleResult = {RuleDescription: string
                   Light: TrafficLight
                   Reason: string}

let createRuleResult ruleSetDescription ruleReason light =
    {RuleDescription=ruleSetDescription;
     Light = light;
     Reason = ruleReason}
 

let evaluate businessObject ruleSet =
    if ruleSet.RedLightRule.IsSome && ruleSet.RedLightRule.Value.Rule businessObject then
        createRuleResult ruleSet.Description ruleSet.RedLightRule.Value.Reason Red
    elif ruleSet.YellowLightRule.IsSome && ruleSet.YellowLightRule.Value.Rule businessObject then
        createRuleResult ruleSet.Description ruleSet.YellowLightRule.Value.Reason Yellow
    else createRuleResult ruleSet.Description "OK" Green
    
let checkRulesForBusinessObject businessRules businessObject =
    List.map (evaluate businessObject) businessRules