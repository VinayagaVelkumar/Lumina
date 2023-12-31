import { Pipe, PipeTransform } from '@angular/core';
import { PAList } from './Models/PAList';

@Pipe({
  name: 'productFilter',
  standalone: false
})
export class ProductFilterPipe implements PipeTransform {

  transform(items: PAList[], category: string, size: string, color:string): PAList[] {
    if (!items) {
      return [];
    }

    return items.filter(item => {
      const matchesCategory = !category || item.category.toLowerCase().includes(category.toLowerCase());
      const matchesColor = !color || item.color.toLowerCase().includes(color.toLowerCase());
      const matchesSize = !size || item.size == size;
      return matchesCategory && matchesSize && matchesColor;
    });
  }

}
