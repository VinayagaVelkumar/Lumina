import { Directive, ElementRef, HostListener, Renderer2 } from '@angular/core';

@Directive({
  selector: '[appHighlightActive]',
  standalone: true
})
export class HighlightActiveDirective {

  constructor(private el: ElementRef, private renderer: Renderer2) { }

  @HostListener('click') onClick() {
    this.renderer.addClass(this.el.nativeElement, 'activenavbar');
  }
}