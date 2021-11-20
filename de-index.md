#### DOMAIN DRIVEN DESIGN
# Refaktorisierung zu einem geschlossenem domänengetriebenen Modell.
Der Workshop und die dazugehörigen Seiten befinden sich derzeit noch in einer frühen Phase der Entstehung.
Ich arbeite in den nächsten 2 Wochen an der Umsetzung.

Aktuell arbeite ich an:
- Initialem Code für die folgenden Übungen
- Hintergrundinformationen zum Workshop
- Bereitstellen des Workshops in deutsch und englisch 

## Hintergrund

In den letzen 20 Jahren habe ich mich immer mehr in der objektorientieren Programmierung spezialisiert. 
Ich bin ein großer Fan der objektorientieren Programmierung und insbesondere von Domain Driven Design. 
Leider stoße ich in meiner täglichen Arbeit immer wieder auf Code, der zwar Objektorientierung suggeriert, aber im Prinzip nichts anderes ist als prozedurale Programmierung verpackt in Klassen.
immer wieder sieht man so genannte anämische Domänenmodelle ([anemic domain  model](https://martinfowler.com/bliki/AnemicDomainModel.html)).
Hierbei handelt es sich um Klassen, die im Prinzip nichts anderes sind als Behälter für Eigenschaften. Dazu gibt es dann meist mehrere „Service“-Klassen die Geschäftslogik implementieren und Eigenschaften auf diesen Klassen lesen und setzen. Nichts widerspricht der objektorientieren mehr als dieser Programmierstil. Denn in der objektorientierten Proframmierung (OOP) geht es darum Daten und Verhalten in einer Klasse zu kapseln. Und genau das ist es wohl, warum ich ein so großer Befürworter von Domain Driven Design geworden bin. Um gut im domänengetriebener Entwicklung zu werden muss man Erfahrung sammeln. Doch diese Erfahrung fehlt vielen, insbesondere wenn man vorher eigentlich fast ausschließlich datengetrieben programmiert hat. Genau dann stößt man fast immer auf die Verwendung anämischer Modelle. Es mag Gründe für ein anemisches Modell geben, nicht jedoch in OOP. Zu meinem Glück macht es mir aber auch Spaß, Entwicklern aufzuzeigen, wie sie ihren Code verbessern können und wie sie zu einem guten Domänenmodell finden. Was mich positiv stimmt sind insbesondere die Aha-Effekte, die Personen erleben, wenn man gemeinsam mit ihnen den Code dahingehend umbaut, dass nach und nach ein Domänenmodell entsteht, dass die geschäftliche Anforderung bestmöglich umsetzt. In diesem Workshop soll es genau darum gehen.
