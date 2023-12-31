import { Pipe, PipeTransform } from '@angular/core';
import { SalePAList } from './Models/SalePAList';

@Pipe({
  name: 'saleFilter',
  standalone: false
})
export class SaleFilterPipe implements PipeTransform {

  transform(items: SalePAList[], category: string, size: string, color:string): SalePAList[] {
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
