#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebMarmelad.Models.CodeFirst;
using WebMarmelad.Models.FilterSortView;
using WebMarmelad.ProductionData;
using WebMarmelad.Models.Weight;
using WebMarmelad.Models.PropertyValueExpert;
using WebMarmelad.Models.Alternativ;

namespace WebMarmelad.Controllers
{
    public class ManyController : Controller
    {
        private readonly ProductionContext _context;

        public ManyController(ProductionContext context)
        {
            _context = context;
        }

        // GET: Many

        public async Task<IActionResult> Index(SortAscDesc sort, int? filterCost, int? filterPower, int? filterPowerCount, int? filterPowerTime,
            bool pareto, bool hierarchy)
        {
            IQueryable<Production> data = _context.Productions;

            bool resultFilter = true;

            if (filterCost.HasValue)
            {
                data = data.Where(s => s.Cost <= filterCost);
            }
            else
            {
                resultFilter = false;
            }

            if (filterPower.HasValue)
            {
                data = data.Where(s => s.Power <= filterPower);
            }
            else
            {
                resultFilter = false;
            }

            if (filterPowerCount.HasValue)
            {
                data = data.Where(s => s.PowerCount >= filterPowerCount);
            }
            else
            {
                resultFilter = false;
            }

            if (filterPowerTime.HasValue)
            {
                data = data.Where(s => s.PowerTime <= filterPowerTime);
            }
            else
            {
                resultFilter = false;
            }

            if (pareto)
            {
                if (resultFilter)
                {
                    Pareto paretoSolution = new Pareto();
                    List<Production> productionSolution = await data.ToListAsync();
                    productionSolution = paretoSolution.GetFindPareto(productionSolution);

                    data = data.Where(p => productionSolution.Select(s => s.Id).Contains(p.Id));

                    sort = SortAscDesc.PowerAsc;
                }
            }

            if (hierarchy)
            {
                if (resultFilter)
                {
                    WeightAlternativ weightAlternativ = new WeightAlternativ(await _context.Expert.ToListAsync());

                    List<Production> productionSolution = await data.ToListAsync();
                    HierarchyMethods hierarchyMethods = new HierarchyMethods(productionSolution, weightAlternativ.GetMassAlternativ());
                    productionSolution = hierarchyMethods.GetProductions();

                    data = data.Where(p => productionSolution.Select(s => s.Id).Contains(p.Id));
                    List<Production> productionSolutionTemp = await data.ToListAsync();

                    for(int i = 0; i < productionSolution.Count; i++)
                    {
                        productionSolutionTemp[i].Weight = productionSolution[i].Weight;
                    }

                    _context.UpdateRange(productionSolutionTemp);
                    _context.SaveChanges();

                    sort = SortAscDesc.PowerAsc;
                }
            }

            data = sort switch
            {
                SortAscDesc.IdAsc => data.OrderBy(s => s.Id),
                SortAscDesc.IdDesc => data.OrderByDescending(s => s.Id),
                SortAscDesc.NameAsc => data.OrderBy(s => s.Name),
                SortAscDesc.NameDesc => data.OrderByDescending(s => s.Name),
                SortAscDesc.CostAsc => data.OrderBy(s => s.Cost),
                SortAscDesc.CostDesc => data.OrderByDescending(s => s.Cost),
                SortAscDesc.PowerAsc => data.OrderBy(s => s.Power),
                SortAscDesc.PowerDesc => data.OrderByDescending(s => s.Power),
                SortAscDesc.WaterAsc => data.OrderBy(s => s.Water),
                SortAscDesc.WaterDesc => data.OrderByDescending(s => s.Water),
                SortAscDesc.AirAsc => data.OrderBy(s => s.Air),
                SortAscDesc.AirDesc => data.OrderByDescending(s => s.Air),
                SortAscDesc.PowerCountAsc => data.OrderBy(s => s.PowerCount),
                SortAscDesc.PowerCountDesc => data.OrderByDescending(s => s.PowerCount),
                SortAscDesc.PowerTimeAsc => data.OrderBy(s => s.PowerTime),
                SortAscDesc.PowerTimeDesc => data.OrderByDescending(s => s.PowerTime),
                SortAscDesc.WeightAsc=> data.OrderBy(s=>s.Weight),
                SortAscDesc.WeightDesc => data.OrderByDescending(s=>s.Weight),
                _ => data
            };

            FilterSortViewModel model = new FilterSortViewModel
            {
                SortModel = new SortModel(sort),
                Productions = await data.ToListAsync(),
                FilterModel = new FilterModel(filterCost, filterPower, filterPowerCount, filterPowerTime)
            };

            return View(model);
        }

        // GET: Many/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var production = await _context.Productions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (production == null)
            {
                return NotFound();
            }

            return View(production);
        }

        // GET: Many/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Many/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Cost,Power,Water,Air,PowerCount,PowerTime,Weight")] Production production)
        {
            if (ModelState.IsValid)
            {
                _context.Add(production);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(production);
        }

        // GET: Many/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var production = await _context.Productions.FindAsync(id);
            if (production == null)
            {
                return NotFound();
            }
            return View(production);
        }

        // POST: Many/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Cost,Power,Water,Air,PowerCount,PowerTime,Weight")] Production production)
        {
            if (id != production.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(production);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductionExists(production.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(production);
        }

        // GET: Many/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var production = await _context.Productions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (production == null)
            {
                return NotFound();
            }

            return View(production);
        }

        // POST: Many/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var production = await _context.Productions.FindAsync(id);
            _context.Productions.Remove(production);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductionExists(int id)
        {
            return _context.Productions.Any(e => e.Id == id);
        }

        public async Task<IActionResult> Weight()
        {
            ValueExpertUtil value = new ValueExpertUtil();
            ViewBag.Weight = value.GetValueExperts();

            WeightAlternativ weightAlternativ = new WeightAlternativ(await _context.Expert.ToListAsync());
            WeightViewModel model = new WeightViewModel()
            {
                PropertyExpertOne = await _context.Expert.Take(5).ToListAsync(),
                PropertyExpertTwo = await _context.Expert.Skip(5).ToListAsync(),
                WeightModel = new WeightModel()
                {
                    CostWeight = weightAlternativ.GetMassAlternativ()[0],
                    PowerWeight = weightAlternativ.GetMassAlternativ()[1],
                    PowerCountWeight = weightAlternativ.GetMassAlternativ()[2],
                    WaterWeight = weightAlternativ.GetMassAlternativ()[3],
                    AirWeignt = weightAlternativ.GetMassAlternativ()[4],
                    BestCriteria = weightAlternativ.GetMassAlternativ()[weightAlternativ.GetIndexBestAlternativ()],
                    NameBestCriteria = GetNameBestCriteria(weightAlternativ.GetIndexBestAlternativ())

                }
            };

            return View(model);
        }

        private string GetNameBestCriteria(int index)
        {
            string name = "";
            switch (index)
            {
                case 0: name = "Стоимость (руб)"; break;
                case 1: name = "Электроэнергия (квТч)"; break;
                case 2: name = "Мощность (ед)"; break;
                case 3: name = "Вода (куб)"; break;
                case 4: name = "Воздух (т)"; break;
                default: break;
            }
            return name;
        }

        [HttpPost]
        public async Task<IActionResult> UpdateWeight(List<int> id, List<int> costIdValue,
            List<int> powerIdValue, List<int> powerCountIdValue, List<int> waterIdValue, List<int> airIdValue)
        {
            for (int i = 0; i < id.Count; i++)
            {
                _context.Expert.Update(new PropertyExpertModel()
                {
                    Id = id[i],
                    CostIdValue = costIdValue[i],
                    PowerIdValue = powerIdValue[i],
                    PowerCountIdValue = powerCountIdValue[i],
                    WaterIdValue = waterIdValue[i],
                    AirIdValue = airIdValue[i]
                });
            }
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Weight));
        }

        public async Task<IActionResult> Reset()
        {
            List<Production> productions = await _context.Productions.ToListAsync();

            foreach(var item in productions)
            {
                item.Weight = 0;
            }

            _context.UpdateRange(productions);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
