import { Component, OnInit } from '@angular/core';
import { UnknownText } from 'src/app/models/text';

@Component({
  selector: 'app-text-create',
  templateUrl: './text-create.component.html',
  styleUrls: ['./text-create.component.css']
})
export class TextCreateComponent implements OnInit {
  text: UnknownText;
  editMode: boolean = true;
  constructor() {
    this.text = new UnknownText();
    //test
    this.text.innerText = `Amy normally hated Monday mornings, but this year was different. Kamal was in her art class and she liked Kamal. She was waiting outside the classroom when her friend Tara arrived.


    “Hi Amy! Your mum sent me a text. You forgot your inhaler. Why don’t you turn your phone on?” Amy didn’t like technology. She never sent text messages and she hated Facebook too.


    “Did Kamal ask you to the disco?” Tara was Amy’s best friend, and she wanted to know everything that was happening in Amy’s life. “I don’t think he likes me,” said Amy. “And I never see him alone. He’s always with Grant.” Amy and Tara didn’t like Grant.


    “Do you know about their art project?” asked Amy. “It’s about graffiti, I think,” said Tara. “They’re working on it at the old house behind the factory.” “But that building is dangerous,” said Amy. “Aah, are you worried he’s going to get hurt?" Tara teased. “Shut up, Tara! Hey look, here they come!”


    Kamal and Grant arrived. “Hi Kamal!” said Tara. “Are you going to the Halloween disco tomorrow?” “Yes. Hi Amy,” Kamal said, smiling. “Do you want to come and see our paintings after school?” “I’m coming too!” Tara insisted.


    After school, Kamal took the girls to the old house. It was very old and very dirty too. There was rubbish everywhere. The windows were broken and the walls were damp. It was scary. Amy didn’t like it. There were paintings of zombies and skeletons on the walls. “We’re going to take photos for the school art competition,” said Kamal. Amy didn’t like it but she didn’t say anything. “Where’s Grant?” asked Tara. “Er, he’s buying more paint.” Kamal looked away quickly. Tara thought he looked suspicious. “It’s getting dark, can we go now?” said Amy. She didn’t like zombies.`;

    this.text.name = 'The text #1';
   }

  ngOnInit() {
  }

  setText() {
    this.editMode = false;
  }
}
