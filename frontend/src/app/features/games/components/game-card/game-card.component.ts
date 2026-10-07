import { Component, Input } from '@angular/core';
import { RawgGame } from '../../models/rawg-game.model';

@Component({
  selector: 'app-game-card',
  templateUrl: './game-card.component.html',
  styleUrls: ['./game-card.component.css']
})
export class GameCardComponent {
  @Input() game!: RawgGame;
}