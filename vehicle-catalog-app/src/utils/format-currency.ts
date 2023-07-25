export function formatCurrency(value: number): string {
  const options = {
    style: 'currency',
    currency: 'BRL',
    minimumFractionDigits: 2,
  };
  return (value / 100).toLocaleString('pt-BR', options);
}